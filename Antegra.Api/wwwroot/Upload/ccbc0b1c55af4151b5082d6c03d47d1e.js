import React, { useEffect, useState } from "react"
import { apiurl, GetNoneToken, PostNoneToken } from "../datacrud/datacrud"

import CurrencyInput from "react-currency-input";
import Dropdown from 'react-dropdown';
import { DispositContainer } from "../Components/containers/DispositContainer";
// import { Helmet } from "react-helmet";
import { dispositRedirect } from "../Components/RedirectComponent";
import { Helmet } from "react-helmet";
import Rimage from "../Components/Rimage";
import { KrediInput } from "../Components/KrediInput";
import KrediSelect from "../Components/KrediSelect";

 const DispositSearchResult = (props) => {
    var [data, setData] = useState([])

    const [currency, setCurrency] = useState("")
    const [termsValue, setTermsValue] = useState()
    const [currencyIcon, setCurrencyIcon] = useState("")
    const [currencyIconStatic, setCurrencyIconStatic] = useState("")
    const [currencyName, setCurrencyName] = useState("")
    const [refreshPage, setRefreshPage] = useState("")

    const [blog, setBlog] = useState([])

    const [amount, setAmount] = useState(null)
    const [amountStatic, setAmountStatic] = useState(null)
    const [termsStatic, setTermsStatic] = useState(0)


    useEffect(() => {
        start()
    }, [])

    const start = async () => {

        let a = parseInt(new URLSearchParams(props.location.search).get("amount")) || 1000
        let c = new URLSearchParams(props.location.search).get("c") || "0"
        let t = parseInt(new URLSearchParams(props.location.search).get("term")) || 5
        setTermsStatic(t)


        let blogList = await GetNoneToken("Blogs/get4Blog").then(x => { return x.data }).catch(x => { return false })
        setBlog(blogList)
        setAmount(a)
        setCurrency(c)
        setTermsValue(t)
        setAmountStatic(a)


        if (c == 0) {
            setCurrencyIconStatic("₺")
            setCurrencyName("TL")
        } else if (c == 1) {
            setCurrencyIconStatic("$")
            setCurrencyName("Dolar")
        } else if (c == 2) {
            setCurrencyIconStatic("€")
            setCurrencyName("Euro")
        }

        var dds = { amount: a, term: t, c: c }
        let data = await PostNoneToken("Disposits/Search", dds).then(x => { return x.data }).catch(x => { return false })

        setData(data)
    }
    const currencIconChange = (c) => {
        if (c == 0) {
            setCurrencyIcon("₺")
        } else if (c == 1) {
            setCurrencyIcon("$")

        } else if (c == 2) {
            setCurrencyIcon("€")
        }
    }
    const calculate = async () => {


        // let prm = new URLSearchParams(props.location.search)
        // prm.set("amount", amount.replace(/\./g, "").replace(currencyIcon, ""))
        // prm.set("term", termsValue)
        // prm.set("c", currency)
        setTermsStatic(termsValue)
        
        window.location.replace("/vadeli-mevduati-hesaplama-ve-basvuru?amount=" + amount + "&term=" + termsValue + "&c=" + currency)
        // setRefreshPage(termsValue)
        start()

    }
    return (
        <>
            <Helmet>

                <meta property="og:type" content="article" />
                <meta property="og:title" content={(amount ?? "") + " " + currencyName + "  Anapara ve " + termsValue + " Vade ile En kazanclı mevduat hesapları | KREDİ.COM.TR"} />
                <meta property="og:url" content={window.location.href} />
                <meta property="og:description" content={(amount ?? "") + " " + currencyName + "  Anapara  " + termsValue + " Vadeli mevduat hesaplarını karşılaştırma ve en kazançlı vadeli mevduat hesabını bulmak ve başvurmak için doğru adres"} />
                <meta name="keyword" content="kredi, kredi kartı, kredi başvurusu, kredi faiz oranı, kredi kartı başvurusu, vadeli mevduat, vadeli mevduat hesabı" />
                                <meta name="og:keyword" content="kredi, kredi kartı, kredi başvurusu, kredi faiz oranı, kredi kartı başvurusu, vadeli mevduat, vadeli mevduat hesabı" />

                <meta name="twitter:title" content={(amount ?? "") + " " + currencyName + "  Anapara ve " + termsValue + " Vade ile En kazanclı mevduat hesapları | KREDİ.COM.TR"} />
                <meta name="twitter:description" content={(amount ?? "") + " " + currencyName + "  Anapara  " + termsValue + " Vadeli mevduat hesaplarını karşılaştırma ve en kazançlı vadeli mevduat hesabını bulmak ve başvurmak için doğru adres"} />
                <meta name="description" content={"Vadeli mevduat hesapları karşılaştırma ve en kazançlı vadeli mevduat hesabını bulmak ve başvurmak için doğru adres"} />
                <meta name="robots" content="index,follow" />
                <title>{(amount ?? "") + " " + currencyName + "  Anapara ve " + termsValue + " Vade ile En kazanclı mevduat hesapları | KREDİ.COM.TR"} </title>

            </Helmet>
            <div className="container">
                <div className=" row">
                    <div className="row mt-3">
                        <div className="col-12  ">
                            <div className="col-12 mb-3">
                                <div className="row" style={{ background: "rgb(169 194 253 / 36%)", padding: "10px 0px 13px 0", border: "1px solid #9fb8ff" }}>
                                    <div className="col-12 col-md-3 ">
                                        <label className="col-12 mb-0">Para Birimi</label>

                                        <KrediSelect
                                            options={[
                                                { value: "0", text: "Türk Lirası" },
                                                { value: "1", text: "Dolar" },
                                                { value: "2", text: "Euro" },

                                            ]}
                                            onChange={(element) => { setCurrency(element.value); currencIconChange(element.value) }}
                                            placeholder="Para Birimi"
                                            arrowClassName="dropdownArrow"
                                            value={currency}
                                        />
                                    </div>

                                    <div className="col-12 col-md-3 mb-2">
                                        <label className="col-12 mb-0">Anapara</label>
                                        <KrediInput style={{ width: "100%", maxWidth: "100%" }} placeholder="Tutar Giriniz" className="col-7"
                                            decimalSeparator=","
                                            thousandSeparator="."
                                            precision="0"
                                            onChange={(x) => { setAmount(x.replace(/\./g, "")) }}
                                            value={amount}

                                            prefix={currencyIcon}
                                        />
                                    </div>
                                    <div className="col-12  col-md-3 mb-2">

                                        <label className="col-12 mb-0">Vade</label>
                                        <input type="text" onChange={(e) => { setTermsValue(e.target.value); }} value={termsValue}></input>
                                    </div>



                                    <div className="col-6 col-md-3 mt-4" style={{ justifyontent: "flex-end", }}>
                                        <button onClick={(x) => { calculate() }} className="default-button" type="submit">TEKRAR ARA</button>
                                    </div>
                                </div>

                            </div>
                            <hr></hr>


                        </div>
                        <div className="row">
                            <div className="col-12 col-md-8">

                                {
                                    data &&
                                    data?.map((item, key) => {
                                        let isPopuler = ""
                                        if (item.isPopuler) {
                                            isPopuler = "special-select"
                                        }
                                        return (
                                            <div key={key} className={"col-12 row loan-search-list-item mb-3 pt-4 " + isPopuler}>
                                                {
                                                    isPopuler != "" &&
                                                    <div className="populer-mark">
                                                        <img style={{ width: 32 }} src={require("../assets/images/special.png").default} /> Sponsorlu
                                                    </div>
                                                }
                                                <div className="col-3">
                                                    <div className="mb-2">
                                                        <Rimage alt={item.bankName + " Vadeli Mevduat Hesapları"} title={item.bankName + " Vadeli Mevduat Hesaplarını Gör"} src={item.bankLogoUrl} style={{ width: "100%" }}></Rimage>
                                                    </div>

                                                    <div className="mb-2" style={{ color: "grey", textAlign: "center" }}>{item.dispositName}</div>
                                                </div>
                                                <div className="col-2">
                                                    <div className="">
                                                        <span style={{ color: "#1a1a1a" }}>Anapara </span>
                                                    </div>

                                                    <div className="mb-2"><b style={{ color: "black" }}>
                                                        <KrediInput style={{
                                                            padding: 0,
                                                            border: "none",
                                                            display: "inline",
                                                            float: "left",
                                                            background: "none",
                                                            color: "black",
                                                            fontWeight: "bold",
                                                            maxWidth: "100%"
                                                        }}
                                                            className="col-7"
                                                            decimalSeparator=","
                                                            thousandSeparator="."
                                                            precision="0"
                                                            disabled
                                                            prefix={currencyIconStatic}
                                                            value={amountStatic} />
                                                    </b></div>
                                                    <div style={{ color: "#f36800" }}>Faiz : <b style={{
                                                        fontSize: 13, fontWeight: "bold",
                                                        color: "#f36800"
                                                    }}>{item.rate}</b>

                                                    </div>
                                                </div>
                                                <div className="col-2">
                                                    <div className="">
                                                        <span style={{ color: "#1a1a1a" }}>Net Kazanç</span>
                                                    </div>

                                                    <div className="mb-2">
                                                        <KrediInput style={{
                                                            padding: 0,
                                                            border: "none",
                                                            display: "inline",
                                                            float: "left",
                                                            background: "none",
                                                            color: "black",
                                                            fontWeight: "bold",
                                                            maxWidth: "100%"

                                                        }}
                                                            className="col-7"
                                                            decimalSeparator=","
                                                            thousandSeparator="."
                                                            precision="2"
                                                            disabled
                                                            prefix={currencyIconStatic}
                                                            value={(item.netAmount).toFixed(0)} />
                                                    </div>
                                                    <div style={{
                                                        fontSize: 13,
                                                        fontWeight: "bold",
                                                        color: "#f36800"
                                                    }}>
                                                        {termsStatic} Gün Vade
                                                    </div>
                                                </div>
                                                <div className="col-3 pt-1 pb-1 text-center" style={{ background: "rgb(255 243 243)", border: "1px solid #ff9999" }}>
                                                    <div className="">
                                                        <span style={{ color: "#1a1a1a", fontSize: 19 }}>Toplam Kazanç</span>
                                                    </div>

                                                    <div style={{ overflow: "hidden" }}>
                                                        <KrediInput style={{
                                                            padding: 0,
                                                            border: "none",
                                                            display: "inline",
                                                            float: "left",
                                                            background: "none",
                                                            color: "black",
                                                            fontWeight: "bold",
                                                            maxWidth: "100%",
                                                            textAlign: "center",
                                                            fontSize: 20

                                                        }}
                                                            className="col-7"
                                                            decimalSeparator=","
                                                            thousandSeparator="."
                                                            precision="0"
                                                            disabled
                                                            prefix={currencyIconStatic}
                                                            value={(item.totalAmount).toFixed(0)}
                                                        />
                                                    </div>

                                                </div>
                                                <div className="col-2 row m-0 justify-content-center align-content-space-between" style={{ height: 80 }}>
                                                    <div className="">
                                                        <button
                                                            onClick={() => dispositRedirect(
                                                                item.redirectUrl,
                                                                item.bankId,
                                                                item.dispositId,
                                                                {
                                                                    bankName: item.bankName,
                                                                    amount: amountStatic.toString(),
                                                                    rate: item.rate.toString(),
                                                                    term: termsValue.toString()
                                                                })}

                                                            className="loan-search-list-item-button default-button">BAŞVUR</button>
                                                    </div>

                                                    <div className="mb-2" style={{ textAlign: "center" }}>
                                                        <a href="" style={{ fontWeight: "bold", color: "rgb(85 0 195)", textDecoration: "underline" }}  >Detay</a>
                                                    </div>
                                                </div>

                                            </div>)

                                    })
                                }
                            </div>
                            <div className="col-12 col-md-4 d-none d-lg-block d-md-block" style={{
                                border: "1px solid #077a68",
                                paddingTop: 10,
                                borderRadius: 8
                            }}>
                                <div className="row">
                                    <div className="col-12 mb-3"><b style={{ color: "black", fontSize: 18 }}>&nbsp;Öne Çıkan Mevduat Hesapları</b> </div>
                                    <DispositContainer Big={true}></DispositContainer>

                                </div>



                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </>
    )
}
export default DispositSearchResult