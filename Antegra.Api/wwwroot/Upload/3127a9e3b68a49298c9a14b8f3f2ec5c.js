import React, { useEffect, useState } from "react"
import { Collapse } from "reactstrap"
import { apiurl, GetNoneToken } from "../datacrud/datacrud"
import calculator from "../Components/calculator"
import ArrowDropDownIcon from '@material-ui/icons/ArrowDropDown';
import ArrowDropUpIcon from '@material-ui/icons/ArrowDropUp';
import Rimage from "../Components/Rimage";
import Seo from "../Components/Seo";
import { PriceSplitter } from "../Components/PriceSplitter";
import CalculatePage from "./CalculatePage";
import HowMuchLoan from "../Components/containers/HowMuchLoan";
import { LoanRate } from "../Components/containers/LoanRate";
import { DispositContainer } from "../Components/containers/DispositContainer";

function MounthlyCalculate(props) {
    const [gelir, setGelir] = useState()
    const [gider, setGider] = useState()
    const [randomTys, setRandomTys] = useState(Math.floor((Math.random() * 3) + 1))

    const [neKadarKredi, setNeKadarKredi] = useState()
    const [resultData, setResultData] = useState([])
    const [collapseId, setCollepseId] = useState(null)
    const [loading, setLoading] = useState(false)
    const [notFound, setNotFound] = useState(false)
    const [resultMoney, setResultMoney] = useState(0)

    async function sleep(msec) {
        return new Promise(resolve => setTimeout(resolve, msec));
    }
    useEffect(() => {
        calculatenw()

    }, [])

    const calculatenw = async () => {

        var Mamount = window.location.pathname.split("/")[2].split("-")[1]
        var MDisamount = window.location.pathname.split("/")[2].split("-")[3]

        var totalM = (Mamount - MDisamount) * 10;

        setCollepseId(null)
        setLoading(true)
        setNotFound(false)
        var loanType = await GetNoneToken("BankLoanRates/GetAllPersonelLoanSite").then(x => { return x.data }).catch(x => { return false })

        loanType = loanType.filter(x => { return x.loanType.includes("İhtiyaç") })
        var gd = parseInt(MDisamount);
        setGider(MDisamount);
        setGelir(Mamount);
        setNeKadarKredi(totalM)
        var result = parseInt(Mamount) - gd
        let loanList = []
        var bankList = []
        setResultMoney(result)
        for (const item of loanType) {
            for (let index = 12; index < 60; index = index + 6) {

                var sa = calculator(parseFloat(item.rate), parseFloat(totalM), parseFloat(index), 5, 15)
                if (result > sa.totalpayment && loanList.filter(x => { return x.bankId == item.bankId })?.length == 0) {

                    if (item.maxAmount > result && item.minAmount < result && item.terms.filter(x => { return x.termValue == index })?.length > 0) {
                        bankList.push({
                            items: [],
                            bankLogoUrl: item.logo,
                            id: item.id,
                            bankUrlName: item.bankUrlName,
                            bankId: item.bankId
                        })
                    }
                }
                if (result > sa.totalpayment) {

                    if (item.maxAmount > result && item.minAmount < result && item.terms.filter(x => { return x.termValue == index })?.length > 0) {

                        loanList.push({
                            mountlyPayment: sa.totalpayment,
                            totalPayment: (parseFloat(sa.totalpayment) * index),
                            rate: item.rate,
                            term: index,
                            bankLogoUrl: item.logo,
                            id: item.id,
                            bankId: item.bankId

                        })
                    }

                }
            }
        }
        let resultList = [];
        for (const item of bankList) {
            let ln = loanList.filter(x => { return x.bankId == item.bankId })
            item.items = ln;
            resultList.push(item)
        }



        await sleep(1000);
        setResultData(resultList)

        if (resultList.length == 0) {
            setNotFound(true)
        }
        setLoading(false)
    }


    return (
        <div className="container cal-mountly-result">
            {!loading &&
                <Seo title={"Aylık " + PriceSplitter(parseInt(gelir)) + " ₺ Gelir Ve" + PriceSplitter(parseInt(gider)) + " Gider İle Kredi Hesaplama"} description={"Aylık " + PriceSplitter(parseInt(gelir)) + " ₺ gelir ve " + PriceSplitter(parseInt(gider)) + " ₺ gider ile kredi hesaplama sonucunda " + neKadarKredi + " ₺ kredi çekebilirsiniz"} />

            }

            <div className="row mt-4">
                <div className="col-12 text-center pt-2 pb-2 zm-mine" style={{
                    border: "1px solid rgb(142, 142, 142)",
                    borderRadius: 10
                }}>


                    {!loading && <>
                        <h1>Aylık <b> {PriceSplitter(parseInt(gelir))} ₺</b> Gelir <b> {PriceSplitter(parseInt(gider))} ₺</b> Gider Kredi Hesaplama</h1>
                        <p>{"Ortalama aylık " + PriceSplitter(parseInt(gelir)) + " ₺ gelir ve aylık ortalama " + PriceSplitter(parseInt(gider)) + " ₺ gider ile kredi hesaplama başarılı bir şekilde yapılmıştır.Bu hesaplama sonucunda "}<b>{PriceSplitter(parseInt(neKadarKredi)) + " ₺ kredi tutarınız bulunuyor"}</b></p>
                        <div className=" row justify-content-center center-co-info">
                            <div className="row col-6">
                                <div className="col-12">
                                    <span> Ortalama Geliriniz : </span> <b> {PriceSplitter(parseInt(gelir)) + " ₺"}</b>
                                </div>

                                <div className="col-12">
                                    <span> Ortalama Giderleriniz : </span> <b>  {" " + PriceSplitter(parseInt(gider)) + " ₺"}</b>
                                </div>

                                <div className="col-12 ">
                                    <span style={{
                                        fontSize: 29,
                                        color: "rgb(251 105 17)"
                                    }}> Çekeceğiniz Tutar : </span>
                                    <b style={{
                                        fontSize: 29,
                                        color: "rgb(251 105 17)"
                                    }}>{"  " + PriceSplitter(parseInt(neKadarKredi)) + " ₺"}</b>

                                </div>



                            </div>

                        </div>
                    </>}

                    {loading && <div className="none-c-div">
                        <h1></h1>
                        <p></p>
                        <div className=" row justify-content-center center-co-info">
                            <div className="row col-6">
                                <div className="col-12">
                                </div>

                                <div className="col-12">
                                </div>

                                <div className="col-12 ">


                                </div>

                            </div>

                        </div>
                    </div>}

                </div>

                <div className="row col-12 result-how-get ">
                    {loading == true &&
                        <div style={{ width: 600, margin: "0 auto" }}>
                            <img alt="loading" style={{ width: "100%" }} src={require("../assets/images/loading.gif").default}></img>

                        </div>
                    }
                    {
                        notFound == true && !isNaN(resultMoney) &&
                        <div style={{ color: "red" }}>Verilere göre size kalan aylık ücret. ({resultMoney} ₺) Geliriniz giderinize göre çok düşük olduğundan uygun kredi bulunamadı! </div>

                    }
                    {
                        isNaN(resultMoney) &&
                        <div style={{ color: "red" }}>Girilen Veriler Hatalı! </div>

                    }

                    {
                        resultData.map((item, key) => {

                            return (
                                <div key={key} className="col-12 row align-items-center how-cal-items mb-4">
                                    <div className="col-3 p-0 text-center">

                                        <Rimage alt={item.bankUrlName} src={item.bankLogoUrl} style={{ width: "70%" }}></Rimage>
                                    </div>
                                    <div className="col-7 p-0 text-center text-dark">

                                        Bu bankada <b style={{ color: "#077a68" }}> {item.items.length} adet  ödeyebileceğinzi kredi </b> bulundu.
                                    </div>
                                    {/* <div className="col-2 p-0">
                                        {
                                            collapseId != item.id &&
                                            <button style={{
                                                border: "1px solid #c3c3c3",
                                                borderRadius: 6,
                                                float: "right"
                                            }} onClick={() => { setCollepseId(item.id) }}> <ArrowDropDownIcon></ArrowDropDownIcon></button>

                                        }
                                        {
                                            collapseId == item.id &&
                                            <button style={{
                                                border: "1px solid #c3c3c3",
                                                borderRadius: 6,
                                                float: "right"
                                            }} onClick={() => { setCollepseId(null) }}> <ArrowDropUpIcon></ArrowDropUpIcon></button>

                                        }
                                    </div> */}
                                    <div className="row justify-content-center m-0 col-12 mt-4 cms-item">

                                        {item.items?.map((jitem, jkey) => {
                                            let color = jkey % 2 == 0 ? { background: "#eeeeee" } : {};
                                            return (
                                                <div style={color} className="pt-2 pb-2 col-12 row justify-content-center" key={jkey} isOpen={collapseId == item.id} >

                                                    <div className="row col-12">
                                                        <div className="col-3">
                                                            <div className="col-12 text-center font-weight-bold">
                                                                Aylık Ödeme
                                                            </div>
                                                            <div className="col-12 text-center text-dark">
                                                                {PriceSplitter(jitem.mountlyPayment.toFixed(2))} ₺

                                                            </div>
                                                        </div>
                                                        <div className="col-1">
                                                            <div className="col-12 text-center font-weight-bold">
                                                                Faiz
                                                            </div>
                                                            <div className="col-12 text-center text-dark">
                                                                {jitem.rate}

                                                            </div>
                                                        </div>
                                                        <div className="col-2">
                                                            <div className="col-12 text-center font-weight-bold">
                                                                Vade
                                                            </div>
                                                            <div className="col-12 text-center text-dark">
                                                                {jitem.term}

                                                            </div>
                                                        </div>
                                                        <div className="col-4 ">
                                                            <div className="col-12 text-center font-weight-bold">
                                                                Toplam Geri Ödeme
                                                            </div>
                                                            <div className="col-12 text-center text-dark">
                                                                {PriceSplitter(jitem.totalPayment.toFixed(2))} ₺

                                                            </div>
                                                        </div>
                                                        <div className="col-2 row align-items-center justify-content-center">
                                                            <a href={"/bankalar/" + item.bankUrlName + "-kredi-hesaplama-ve-basvuru?amount=" + neKadarKredi + "&term=" + jitem.term + "&loanId=" + jitem.id} style={{ color: "white" }} className="default-button row justify-content-center">İncele</a>
                                                        </div>
                                                    </div>
                                                </div>
                                            )

                                        })

                                        }
                                    </div>

                                </div>
                            )
                        })
                    }
                </div>
            </div>
            <div className="col-12 ab-fonts  mb-3">
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
                    {randomTys == 3 &&
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






                </div>
            </div>
        </div>
    );
}

export default MounthlyCalculate;