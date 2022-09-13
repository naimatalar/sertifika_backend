import React, { useEffect, useRef, useState } from "react"
import CurrencyInput from "react-currency-input"
import bankdemodata from "../bankdemodata"
import calculator from "../Components/calculator"
import Dropdown from 'react-dropdown';
import { Link } from "react-router-dom";
import { apiurl, GetNoneToken, PostNoneToken } from "../datacrud/datacrud";
import { loanRedirect } from "../Components/RedirectComponent";
import Rimage from "../Components/Rimage";
import Seo from "../Components/Seo";
import { PriceSplitter } from "../Components/PriceSplitter";
import { LoanSearch } from "../Components/containers/LoanSearch";
import CalculatePage from "./CalculatePage";
import { BankContainer } from "../Components/containers/BankContainer";
import HowMuchLoan from "../Components/containers/HowMuchLoan";
import { LoanRate } from "../Components/containers/LoanRate";
import { DispositContainer } from "../Components/containers/DispositContainer";
import { FastLoan } from "../Components/containers/FastLoan";
import { KrediInput } from "../Components/KrediInput";
import KrediSelect from "../Components/KrediSelect";

const LoanBank = (props) => {
    const [bank, setBank] = useState({})
    const [loanType, setLoanType] = useState({})
    const [loanTermsDropdown, setLoanTermsDropdown] = useState([])
    const [amt, setAmt] = useState(new URLSearchParams(props.location.search).get("amount"))
    const [trm, setTrm] = useState(new URLSearchParams(props.location.search).get("term"))
    const [randomTys, setRandomTys] = useState(Math.floor((Math.random() * 5) + 1))
    const [rateStatic, setRateStatic] = useState()

    const [creditCart, setCreditCart] = useState([])

    const [calcuateResult, setCalculateResult] = useState({
        totalpayment: 0,
        totalVergi: 0,
        totalFaiz: 0,
        paymentPlan: [{
            tutar: 0,
            faiz: 0,
            vergi: 0,
            odenen: 0,
        }]
    })
    const tableHeader = useRef(null)
    const [tableHeaderWidth, setTableHeaderWidth] = useState(0)

    let amount = new URLSearchParams(props.location.search).get("amount")
    let term = new URLSearchParams(props.location.search).get("term")
    let loanId = new URLSearchParams(props.location.search).get("loanId")

    useEffect(() => {

        setTableHeaderWidth(tableHeader.current.offsetWidth);
        function handleResize() {
            if (tableHeader != null) {
                setTableHeaderWidth(tableHeader.current.offsetWidth);
            }
        }
        if (loanId) {
            start()
        }

        window.addEventListener('resize', handleResize);
        return () => window.removeEventListener('resize', handleResize);
    }, [])

    const start = async () => {
        let bankData = await GetNoneToken("Banks/GetAllBankSiteMinById/" + props.BankId + "/" + loanId).then(x => { return x.data }).catch(x => { return false })

        if (bankData) {
            let lt = bankData.loans.find((x) => { return x.id == loanId })
            setLoanTermsDropdown(bankData.terms)
            setLoanType(lt)
            setBank(bankData)

            var plan = calculator(parseFloat(lt?.rate), parseInt(amount), parseInt(trm), 5, 15)
            setRateStatic(lt?.rate)
            setCalculateResult(plan)
        }
        let creditCart = await GetNoneToken("CreditCarts/GetOnlyFive").then(x => { return x.data }).catch(x => { return false })

        setCreditCart(creditCart)

    }

    const calculate = () => {
        // var plan = calculator(parseFloat(loanType?.rate), parseInt(amount), parseInt(trm), 5, 15)
        // setCalculateResult(plan)
        let prm = new URLSearchParams(props.location.search)
        prm.set("amount", amt)
        prm.set("term", trm)
        prm.set("loanId", loanId)
        // props.history.push(window.location.pathname + "?" + prm)
         window.location.replace(window.location.pathname + "?" + prm)
    }

    const updateSelectedLoanOption = (r = null, a = null, t = null) => {

        var ss = bank?.loans?.find(x => {

            if (
                x.minAmount <= parseInt((a != null ? a : amount)) &&
                x.maxAmount >= parseInt((a != null ? a : amount)) &&
                x.loanUrlName == loanType.loanUrlName

            ) {
                return true
            }

        });
        if (ss) {
            setLoanTermsDropdown(ss.terms)
            setLoanType(ss)
            setTrm(ss.terms[0])
            setTrm(t != null ? t : trm)
        } else {
            setLoanTermsDropdown([])
            setTrm("")

        }

        setAmt(a != null ? a : amt)

    }


    return (

        <div>

            <div className="master-content">
                <div className="row  mb-5" style={{ background: "white" }} >
                    <div className="col-12 col-lg-4 col-md-4" style={{ borderRight: "1px solid #b1b1b1" }}>
                        <div className="row">
                            <div className="col-12">
                                <Rimage title={bank?.bankName + " banka " + loanType?.loanName + "kredisi sorgulama soçuçları  kredi.com.tr"} alt={"logo"} style={{ width: "100%" }} src={bank.logoUrl}></Rimage>
                            </div>

                        </div>

                        <div className="row mt-2 pr-3 pl-3">

                            <div className="col-12">

                                <div> <b style={{ color: "black" }}>Tutar</b></div>

                                <KrediInput style={{
                                    float: "left",
                                    minWidth: 60,
                                }}
                                    placeholder="Tutar Giriniz"
                                    className="col-12"
                                    decimalSeparator=","
                                    thousandSeparator="."
                                    precision="0"
                                    prefix="₺"
                                    value={amt}
                                    onChange={(val) => { updateSelectedLoanOption(null, val.replace("₺", "").replace(/\./g, ""), null); setAmt(val.replace("₺", "").replace(/\./g, "")) }}
                                />
                                <div> <b style={{ color: "black" }}>Vade</b></div>
                                <KrediSelect
                                    options={loanTermsDropdown || []}
                                    onChange={(val) => { updateSelectedLoanOption(null, null, val.value) }}
                                    prefix="Vade: "
                                    value={isNaN(parseInt(trm).toString()) ? "":parseInt(trm).toString()}
                                />

                            </div>
                            <div className="col-12 mt-3">
                                <button onClick={() => calculate()} className="default-button justify-content-center text-center" >Kredi Hesapla</button>


                            </div>



                        </div>
                    </div>

                    <div className="col-12 col-lg-8 col-md-8 mt-3 mt-3 pl-4 pr-4">
                        <div className="row loan-info-grid" >
                            <div className="col-12">
                                <h1> {`${bank.bankName} ${loanType?.loanName} Kredi Hesaplama Ve Başvuru`}</h1>
                                <hr className="title-hr mt-3"></hr>
                            </div>


                            <div className="col-12 col-lg-6 pt-2 pb-2">
                                <b className=" col-6" style={{ color: "#797979" }}>Faiz Oranı:</b>
                                <b className="col-6" style={{ color: "black" }}>   {rateStatic}</b>
                            </div>
                            <div className="col-12 col-lg-6 pt-2 pb-2">
                                <b className=" col-6" style={{ color: "#797979" }}>Toplam Faiz:</b>
                                <b className="col-6" style={{ color: "black" }}>
                                    <KrediInput style={{
                                        padding: 0,
                                        border: "none",
                                        display: "inline",
                                        fontWeight: "bold",
                                        width: "auto",
                                        background: "none"
                                    }}
                                        className="col-7"
                                        decimalSeparator="."
                                        thousandSeparator="."
                                        precision="0"
                                        disabled
                                        prefix="₺"
                                        value={calcuateResult.totalFaiz.toFixed(0)} />
                                </b>
                            </div>
                            <div className="col-12 col-lg-6 pt-2 pb-2">
                                <b className=" col-6" style={{ color: "#797979" }}>Toplam Vergi:</b>
                                <b className="col-6" style={{ color: "black" }}>
                                    <KrediInput style={{
                                        padding: 0,
                                        border: "none",
                                        display: "inline",
                                        fontWeight: "bold",
                                        width: "auto",
                                        background: "none"
                                    }}
                                        className="col-7"
                                        decimalSeparator="."
                                        thousandSeparator="."
                                        precision="0"
                                        disabled
                                        prefix="₺"
                                        value={calcuateResult.totalVergi.toFixed(0)} />
                                </b>
                            </div>
                            <div className="col-12 col-lg-6 pt-2 pb-2">
                                <b className=" col-4" style={{ color: "#797979" }}>Ödenecek Tutar:</b>
                                <b className="col-8" style={{ color: "black" }}>
                                    <KrediInput style={{
                                        padding: 0,
                                        border: "none",
                                        display: "inline",
                                        fontWeight: "bold",
                                        width: "auto",
                                        background: "none"
                                    }}

                                        decimalSeparator="."
                                        thousandSeparator="."
                                        precision="0"
                                        disabled
                                        prefix="₺"
                                        value={(calcuateResult.totalpayment * parseInt(term)).toFixed(0)} />
                                </b>
                            </div>
                            <div className="col-12 mt-3">
                                <h2 style={{ fontSize: 17 }}>
                                    Bu kredi hesaplama  <b>
                                        <KrediInput style={{
                                            padding: 0,
                                            border: "none",
                                            display: "inline",
                                            fontWeight: "bold",
                                            width: 90,
                                            background: "none",
                                            textAlign: "center"
                                        }}
                                            className="col-7"
                                            decimalSeparator="."
                                            thousandSeparator="."
                                            precision="0"
                                            disabled
                                            prefix="₺"
                                            value={amount} />
                                    </b> tutarında, <b>{term} </b> vade ile hesaplanmıştır. Hesaplanan kredinin ödeme planı aşağıdadır <br />

                                    <b style={{ fontSize: 12, color: "#077a68" }}><i style={{ color: "#077a68" }}>*Faiz oranı kredi notunuza göre değişiklik gösterebilir</i></b>
                                </h2>
                            </div>
                            <div className="col-12">
                                <div className="row mt-4 pt-3 pb-3" style={{ borderTop: "1px solid #b1b1b1" }}>
                                    <div className="col-4">
                                        <div className=" col-12" style={{ color: "#797979", fontWeight: "bold", fontSize: 18 }}>Aylık Taksit:</div>
                                        <div className="col-12" style={{ color: "black", fontWeight: "bold", fontSize: 25 }}>
                                            <KrediInput style={{
                                                padding: 0,
                                                border: "none",
                                                display: "inline",
                                                float: "left",
                                                minWidth: 60,
                                                background: "none",
                                                fontWeight: "bold"
                                            }}
                                                className="col-7"
                                                decimalSeparator=","
                                                thousandSeparator="."
                                                precision="0"
                                                disabled
                                                prefix="₺"
                                                value={(calcuateResult.totalpayment).toFixed(0)} />

                                        </div>
                                    </div>
                                    <div className="col-8">
                                        <button style={{
                                            background: "#0f8f9c",
                                            fontWeight: "bold",
                                            color: "white",
                                            height: "100%"
                                        }} onClick={() => loanRedirect(loanType?.loanUrlName, loanType?.redirectUrl, bank.id, loanId, { bankName: bank.bankName, amount: amount, loanName: loanType?.loanName, rate: loanType?.rate.toString(), term: term })} className="default-button justify-content-center text-center" >Başvur</button>

                                    </div>

                                </div>

                            </div>
                        </div>
                    </div>
                </div>




                <div className="row">
                    <div className="col-12">
                        <h2 style={{ color: "black" }}>Başvuru Detayı</h2>
                        <hr className="title-hr" />
                        <p style={{ color: "black", fontSize: 18 }}> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Hesaplamanın sonucunda, <b>{PriceSplitter(amount)} TL</b> tutarındaki <b>{loanType?.loanName}</b>,  aylık vadesine göre listelenmiştir. Çekmek istediğiniz kredi
                            <b>{rateStatic}</b> faiz oranıyla hesaplanmıştır. Bu durumda <b>{term}</b> ay boyunca aylık {PriceSplitter((calcuateResult.totalpayment).toFixed(0))} TL ödeme yapılacaktır. Vergiler faiz oranıyla birlikte hesaplanmıştır. Aylık {PriceSplitter((calcuateResult.totalpayment).toFixed(0))} TL tutarın içinde BSMV(Banka ve Sigorta Muameleleri Vergisi) ve KKDF (Kaynak Kullanımı Destekleme Fonu) dahil edilmiştr.
                            Bu ücretler banka tarafından tahsil edilip devlete iade edilir. </p>

                    </div>
                    <div className="col-12">
                        <h4 style={{
                            color: "black",
                            fontWeight: "bold",
                            marginBottom: "28px"
                        }}>Ödeme Planı</h4>
                        <div ref={tableHeader} style={{ position: "relative" }}>



                            <div className="div-table">

                                <div className="div-table-row div-table-header">
                                    <div className="div-table-col pl-2" style={{ width: 50 }}> №</div>
                                    <div className="div-table-col">Kalan Ana Para</div>
                                    <div className="div-table-col">Ödenen</div>
                                    <div className="div-table-col">Ödenen Faiz</div>
                                    <div className="div-table-col">Ödenen Vergi</div>
                                    <div className="div-table-col">Aylık Taksit</div>
                                </div>
                                {
                                    calcuateResult.paymentPlan.map((item, key) => {


                                        let color = key % 2 == 0 ? { background: "#e8e8e8" } : {};

                                        if (item.odenen != 0) {
                                            return (
                                                <div key={key} className="div-table-row" style={color}>
                                                    <div className="div-table-col pl-2" style={{ width: 50 }}>{key + 1}</div>
                                                    <div className="div-table-col">
                                                        <KrediInput style={{
                                                            padding: 0,
                                                            border: "none",
                                                            display: "inline",
                                                            float: "left",
                                                            minWidth: 60,
                                                            background: "none"
                                                        }}
                                                            className="col-7"
                                                            decimalSeparator=","
                                                            thousandSeparator="."
                                                            precision="0"
                                                            disabled
                                                            prefix="₺"
                                                            value={item.tutar.toFixed(0)} />
                                                    </div>
                                                    <div className="div-table-col">
                                                        <KrediInput style={{
                                                            padding: 0,
                                                            border: "none",
                                                            display: "inline",
                                                            float: "left",
                                                            minWidth: 60,
                                                            background: "none"
                                                        }}
                                                            className="col-7"
                                                            decimalSeparator=","
                                                            thousandSeparator="."
                                                            precision="0"
                                                            disabled
                                                            prefix="₺"
                                                            value={item.odenen.toFixed(0)} />
                                                    </div>
                                                    <div className="div-table-col">
                                                        <KrediInput style={{
                                                            padding: 0,
                                                            border: "none",
                                                            display: "inline",
                                                            float: "left",
                                                            minWidth: 60,
                                                            background: "none"
                                                        }}
                                                            className="col-7"
                                                            decimalSeparator=","
                                                            thousandSeparator="."
                                                            precision="0"
                                                            disabled
                                                            prefix="₺"
                                                            value={item.faiz.toFixed(0)} />
                                                    </div>
                                                    <div className="div-table-col">
                                                        <KrediInput style={{
                                                            padding: 0,
                                                            border: "none",
                                                            display: "inline",
                                                            float: "left",
                                                            minWidth: 60,
                                                            background: "none"
                                                        }}
                                                            className="col-7"
                                                            decimalSeparator=","
                                                            thousandSeparator="."
                                                            precision="0"
                                                            disabled
                                                            prefix="₺"
                                                            value={item.vergi.toFixed(0)} />
                                                    </div>
                                                    <div className="div-table-col">
                                                        <KrediInput style={{
                                                            padding: 0,
                                                            border: "none",
                                                            display: "inline",
                                                            float: "left",
                                                            minWidth: 60,
                                                            background: "none"
                                                        }}
                                                            className="col-7"
                                                            decimalSeparator=","
                                                            thousandSeparator="."
                                                            precision="0"
                                                            disabled
                                                            prefix="₺"
                                                            value={(item.odenen + item.faiz + item.vergi).toFixed(0)} />

                                                    </div>
                                                </div>
                                            )
                                        }
                                    })
                                }

                            </div>
                        </div>
                    </div>
                    <div className="row">
                        <div className="row mt-5">

                            <div className="col-12 ab-fonts ">
                                <div className="row justify-content-center">
                                    {randomTys == 1 &&
                                        <>

                                            <a href="/kredi-hesaplama/20000-tl-36-ay-vade-ihtiyac-kredisi" className="col-12 col-md-3 col-lg-3 m-3">
                                                <h3>20.000 TL Ve 36 Ay Vade</h3>
                                                <p>36 ay vade ile hesaplanmış 20.000 TL tutarında kredi veren bankalar</p>
                                            </a>
                                            <a href="/kredi-hesaplama/30000-tl-12-ay-vade-ihtiyac-kredisi" className="col-12 col-md-3 col-lg-3 m-3">
                                                <h3>30.000 TL Ve 12 Ay Vade</h3>
                                                <p>12 ay vade ile hesaplanmış 30.000 TL tutarında kredi veren bankalar</p>
                                            </a>
                                            <a href="/kredi-hesaplama/35000-tl-18-ay-vade-ihtiyac-kredisi" className="col-12 col-md-3 col-lg-3 m-3">
                                                <h3>35.000 TL Ve 18 Ay Vade</h3>
                                                <p>18 ay vade ile hesaplanmış 35.000 TL tutarında kredi veren bankalar</p>
                                            </a>
                                            <a href="/kredi-hesaplama/40000-tl-24-ay-vade-ihtiyac-kredisi" className="col-12 col-md-3 col-lg-3 m-3">
                                                <h3>40.000 TL Ve 24 Ay Vade</h3>
                                                <p>24 ay vade ile hesaplanmış 40.000 TL tutarında kredi veren bankalar</p>
                                            </a>

                                            <a href="/kredi-hesaplama/60000-tl-36-ay-vade-ihtiyac-kredisi" className="col-12 col-md-3 col-lg-3 m-3">
                                                <h3>60.000 TL Ve 36 Ay Vade</h3>
                                                <p>36 ay vade ile hesaplanmış 60.000 TL tutarında kredi veren bankalar</p>
                                            </a>
                                            <a href="/kredi-hesaplama/65000-tl-24-ay-vade-ihtiyac-kredisi" className="col-12 col-md-3 col-lg-3 m-3">
                                                <h3>65.000 TL Ve 24 Ay Vade</h3>
                                                <p>36 ay vade ile hesaplanmış 65.000 TL tutarında kredi veren bankalar</p>
                                            </a>
                                        </>
                                    }
                                    {randomTys == 2 &&
                                        <>

                                            <a href="/kredi-hesaplama/25000-tl-12-ay-vade-ihtiyac-kredisi" className="col-12 col-md-3 col-lg-3 m-3">
                                                <h3>25.000 TL Ve 12 Ay Vade</h3>
                                                <p>12 ay vade ile hesaplanmış 25.000 TL tutarında kredi veren bankalar</p>
                                            </a>
                                            <a href="/kredi-hesaplama/30000-tl-18-ay-vade-ihtiyac-kredisi" className="col-12 col-md-3 col-lg-3 m-3">
                                                <h3>30.000 TL Ve 18 Ay Vade</h3>
                                                <p>18 ay vade ile hesaplanmış 30.000 TL tutarında kredi veren bankalar</p>
                                            </a>
                                            <a href="/kredi-hesaplama/40000-tl-24-ay-vade-ihtiyac-kredisi" className="col-12 col-md-3 col-lg-3 m-3">
                                                <h3>40.000 TL Ve 24 Ay Vade</h3>
                                                <p>24 ay vade ile hesaplanmış 40.000 TL tutarında kredi veren bankalar</p>
                                            </a>
                                            <a href="/kredi-hesaplama/44000-tl-18-ay-vade-ihtiyac-kredisi" className="col-12 col-md-3 col-lg-3 m-3">
                                                <h3>45.000 TL Ve 18 Ay Vade</h3>
                                                <p>18 ay vade ile hesaplanmış 45.000 TL tutarında kredi veren bankalar</p>
                                            </a>

                                            <a href="/kredi-hesaplama/65000-tl-24-ay-vade-ihtiyac-kredisi" className="col-12 col-md-3 col-lg-3 m-3">
                                                <h3>65.000 TL Ve 24 Ay Vade</h3>
                                                <p>24 ay vade ile hesaplanmış 65.000 TL tutarında kredi veren bankalar</p>
                                            </a>
                                            <a href="/kredi-hesaplama/70-tl-18-ay-vade-ihtiyac-kredisi" className="col-12 col-md-3 col-lg-3 m-3">
                                                <h3>70.000 TL Ve 24 Ay Vade</h3>
                                                <p>18 ay vade ile hesaplanmış 70.000 TL tutarında kredi veren bankalar</p>
                                            </a>
                                        </>
                                    }
                                    {randomTys != 2 && randomTys != 1 &&
                                        <>

                                            <a href="/kredi-hesaplama/25000-tl-12-ay-vade-ihtiyac-kredisi" className="col-12 col-md-3 col-lg-3 m-3">
                                                <h3>15.000 TL Ve 12 Ay Vade</h3>
                                                <p>12 ay vade ile hesaplanmış 15.000 TL tutarında kredi veren bankalar</p>
                                            </a>
                                            <a href="/kredi-hesaplama/10000-tl-24-ay-vade-ihtiyac-kredisi" className="col-12 col-md-3 col-lg-3 m-3">
                                                <h3>10.000 TL Ve 18 Ay Vade</h3>
                                                <p>18 ay vade ile hesaplanmış 10.000 TL tutarında kredi veren bankalar</p>
                                            </a>
                                            <a href="/kredi-hesaplama/30000-tl-36-ay-vade-ihtiyac-kredisi" className="col-12 col-md-3 col-lg-3 m-3">
                                                <h3>30.000 TL Ve 36 Ay Vade</h3>
                                                <p>36 ay vade ile hesaplanmış 30.000 TL tutarında kredi veren bankalar</p>
                                            </a>
                                            <a href="/kredi-hesaplama/40000-tl-24-ay-vade-ihtiyac-kredisi" className="col-12 col-md-3 col-lg-3 m-3">
                                                <h3>40.000 TL Ve 24 Ay Vade</h3>
                                                <p>24 ay vade ile hesaplanmış 40.000 TL tutarında kredi veren bankalar</p>
                                            </a>

                                            <a href="/kredi-hesaplama/65000-tl-24-ay-vade-ihtiyac-kredisi" className="col-12 col-md-3 col-lg-3 m-3">
                                                <h3>65.000 TL Ve 24 Ay Vade</h3>
                                                <p>24 ay vade ile hesaplanmış 65.000 TL tutarında kredi veren bankalar</p>
                                            </a>
                                            <a href="/kredi-hesaplama/70-tl-18-ay-vade-ihtiyac-kredisi" className="col-12 col-md-3 col-lg-3 m-3">
                                                <h3>70.000 TL Ve 24 Ay Vade</h3>
                                                <p>18 ay vade ile hesaplanmış 70.000 TL tutarında kredi veren bankalar</p>
                                            </a>
                                        </>
                                    }






                                </div>
                                {randomTys == 1 &&
                                    <div className="row">
                                        <CalculatePage UrlName="aylik-ne-kadar-odeyebilirim" />
                                    </div>
                                }
                                {randomTys == 2 &&
                                    <div className="row unset-d">
                                        <div className="col-12 col-md-6 col-lg-6  ">
                                            <HowMuchLoan></HowMuchLoan>
                                        </div>
                                        <div className="col-12 col-md-6 col-lg-6 ">
                                            <LoanRate></LoanRate>
                                        </div>
                                    </div>
                                }
                                {randomTys == 3 &&
                                    <div className="row unset-d">
                                        <div className="col-12 col-md-6 col-lg-6 lrtt">
                                            <DispositContainer Big></DispositContainer>
                                        </div>

                                        <div className="col-12 col-md-6 col-lg-6 lrtt">
                                            <LoanRate></LoanRate>
                                        </div>
                                    </div>
                                }
                                {randomTys == 4 &&
                                    <div className="row unset-d">
                                        <div className="col-12 col-md-6 col-lg-6 lrtt">
                                            <FastLoan ></FastLoan>
                                        </div>

                                        <div className="col-12 col-md-6 col-lg-6 lrtt">
                                            <LoanRate></LoanRate>
                                        </div>
                                    </div>
                                }


                                <div className="mb-3 mt-2"><h4>Popüler Kredi Kartları</h4> </div>
                                <hr className="title-hr"></hr>
                                <div className="row mt-5 ">
                                    {

                                        creditCart.map((item, key) => {
                                            var jsondata = item.cartInfoJson;
                                            return (
                                                <div key={key} className="col-12 col-lg-4 col-md-4  mb-5 blog-page-credit-cart-item">
                                                    <div className="credit-cart-blog-page row">

                                                        <div className="col-6 mb-2">
                                                            <Rimage src={item.logoUrl} style={{ width: "100%" }}></Rimage>
                                                        </div>
                                                        <div className="col-6 p-0 ">
                                                            <p style={{ color: "black", fontSize: 12 }}>Yıllık Kullanım Ücreti :<b>{item.yearlyUsingAmount} TL</b></p>
                                                            <a className="default-button" style={{ width: "100%", display: "block", textAlign: "center" }} href={"/" + item.bankUrlName + "/" + item.urlName}> Detay </a>
                                                        </div>
                                                        {
                                                            jsondata?.map((jitem, jkey) => {
                                                                return (

                                                                    <div className="col-12 row credit-cart-detail " key={jkey}>
                                                                        <div className="col-6 ">
                                                                            <b> {jitem.key}</b>  :
                                                                        </div>
                                                                        <div className="col-6 ">
                                                                            {jitem.value}
                                                                        </div>

                                                                    </div>
                                                                )
                                                            })

                                                        }

                                                    </div>
                                                    {/* <div className="col-12 mt-2">
                                            <a className="blog-credit-cart-detail-button" href={"/" + item.bankUrlName + "/" + item.urlName}><b style={{ color: "blue" }}>Devamı...</b></a>
                                        </div> */}
                                                </div>
                                            )
                                        })

                                    }


                                </div>
                                <div className="row justify-content-center">
                                    <BankContainer Banks={props.Banks}></BankContainer>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
            <Seo
                description={`Bu kredi hesaplama ${amount} tutarında ,${term} vade ile hesaplanmıştır. Hesaplanan kredinin ödeme planı aşağıdadır `}
                title={`${bank.bankName} ${loanType?.loanName} Kredi Hesaplama Ve Başvuru`}
                keyword={`${loanType?.bankName},${loanType?.loanName} hesapla, hesapla, kredi hesaplama, başvuru, ${bank.bankName} hesaplama,${loanType?.loanName} başvuru `}
            />
        </div >

    )
}


export default LoanBank