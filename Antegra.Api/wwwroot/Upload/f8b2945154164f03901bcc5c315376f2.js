import React, { useEffect, useState } from "react"
import CurrencyInput from "react-currency-input";
import Dropdown from 'react-dropdown';
import { GetNoneToken, PostNoneToken } from "../datacrud/datacrud";
import { PopulerLoans } from "../Components/containers/PopulerLoans";
import { Helmet } from "react-helmet";
import { HowToPay } from "../Components/calculate-page/HowToPay";
import { LoanRate } from "../Components/containers/LoanRate";
import Image from "react-image-webp";
import { KrediInput } from "../Components/KrediInput";

import KrediSelect from "../Components/KrediSelect";
export const Loan = (props) => {
    const [loan, setLoan] = useState(props.Loan)
    const [amount, setAmount] = useState()
    const [terms, setTerms] = useState([])
    const [termsValue, setTermsValue] = useState()
    const [howMuchCalculate, setHowMuchCalculate] = useState()
    const [isValid, setIsValid] = useState(true)


    useEffect(() => {

        start()
    }, [props.Loan])

    const start = async () => {
        var terms = await GetNoneToken("InterestRates/GetLoanTerms/" + loan.id).then(x => { return x.data }).catch(x => { return false })

        let termsList = [];
        terms?.map((item, key) => {
            termsList.push({ value: item, text: item })
        })
        setTerms(terms)

    }

    const calculate = async () => {
        var data = {
            loanTypeId: loan.id,
            amount: (amount != null ? amount.replace("₺", "").replace(/\./g, "") : ""),
            term: termsValue
        }

        if (data.amount > 0 && data.term && loan.urlName) {
            setIsValid(true)
            let prm = new URLSearchParams()
            prm.set("amount", data.amount)
            prm.set("term", data.term)

            // props.history.push("/" + loan.urlName + "-arama-hesaplama?" + prm)
            window.history.pushState({}, "", "/kredi-hesaplama/" + data.amount + "-tl-" + data.term + "-ay-vade-" + loan.urlName)
            window.history.go()
        } else {
            setIsValid(false)
        }


    }
    return (
        <div className="master-content" id="rtt">

            <div className="container-fluid">
                <div className="loan-search-container-label pt-5">
                    {/* <h3 className="loan-page-title">{loan.loanName.toLocaleUpperCase()} ARA</h3> */}
                    <div className="row loan-search-content-label justify-content-center">
                        <div className="col-12 col-md-7 col-lg-7 row d-flex d-lg-none d-md-none justify-content-center">
                            {getContent(loan.urlName)}

                        </div>
                        <div className="col-12 col-md-5 col-lg-5">


                            <div className="col-12">
                                <div className="col-12 mb-4">
                                    <KrediInput style={{ width: "100%", maxWidth: "100%" }} placeholder="Tutar Giriniz" className="col-7"
                                        decimalSeparator=","
                                        thousandSeparator="."
                                        precision="0"
                                        onChange={(x) => { setAmount(x) }}
                                        value={amount}
                                        prefix="₺"

                                    />

                                </div>
                                <div className="col-12 mb-4 ">
                                    <KrediSelect
                                        options={
                                            terms
                                        }
                                        onChange={(d) => { setTermsValue(d.value) }}
                                        value="36"
                                        prefix="Vade: "
                                    />

                                    {/* {terms.length > 0 &&
                                        <Picker
                                            // options={terms}
                                           

                                            valueGroups={
                                                {
                                                    data: terms[0]?.value,
                                                }
                                            }

                                            optionGroups={{
                                                // data: [terms.map(ele=> ele.value)],
                                                data: terms?.map(ele => { return ele.label })

                                            }}
                                        />} */}
                                </div>
                                <div className="col-12 " style={{ justifyontent: "flex-end", marginTop: 12 }}>
                                    <button onClick={(x) => { calculate() }} className="default-button" type="submit">Kredi Hesapla</button>
                                </div>
                                <div className="col-12 text-center">
                                    {!isValid && <b style={{ color: "red" }}>***Bilgileri eksiksiz doldurunuz</b>}

                                </div>
                            </div>
                        </div>
                        <div className="col-12 col-md-7 col-lg-7 row d-none d-lg-flex d-md-flex">
                            {getContent(loan.urlName)}

                        </div>
                    </div>

                </div>
                <div className="row">
                    <div className="mt-5 col-12 col-md-8 col-lg-8">

                        <HowToPay></HowToPay>
                    </div>
                    <div className="mt-5 col-12 col-md-4 col-lg-4">
                        <div className="col-12 mb-3 mt-3"><h2>Kredi Puanı Nedir?</h2><hr className="title-hr mt-1"></hr></div>
                        <p style={{ color: "black" }}>
                            &nbsp; &nbsp; &nbsp; &nbsp;  Kredi puanı, BDDK tarafından kişinin kredi ve kredi kartı kullanımına göre belirlenir. <br></br> <br></br> &nbsp; &nbsp; &nbsp; &nbsp;
                            <small style={{ color: "black" }}>Kişi herhangi bir bankaya kredi başvurusunda bulunduğunda ilgili banka,kişinin kredi puanını göz önünde bulundurur.</small>
                            <br></br><br></br>
                            <b style={{ color: "black" }}>Kredi Puanını Etkileyen şeyler Nedir ?</b>
                            <br></br><br></br>
                            &nbsp; &nbsp; &nbsp; &nbsp; <small style={{ color: "black" }}> Kullandığınız kredi ve kredi kartlarını zamanında ödemeniz, hangi sıklıkta kredi kullandığınız, erken kapatma işlemleri gibi kriterler kredi puanını etkiler.
                                Kredi çekmeniz gerekiyor ve puanınız düşük ise kredi kartı alıp 6 ay yada daha fazla bir süre düzenli ödemeniz kredi puanınızı yükseltecektir.</small>
                        </p>
                        <br></br>
                        <a href="https://www.findeks.com/">Kredi Puanınızı Öğrenmek İçin Tıklayın</a>
                    </div>
                </div>



                <div className="col-12 mt-5">
                    <p className="home-title" >
                        <span style={{ fontWeight: "bold" }}>Kredi fırsatlarını </span>
                        parmaklarınızın ucuna getiriyoruz. Birbirinden farklı ve çeşitli
                        <span style={{ fontWeight: "bold" }}> kredi türleri ve kredi kartlarını
                        </span> sizler için seçip sorguluyoruz. </p>

                </div>
                <div className="row">
                    <div className="col-12 col-md-6 col-lg-6 mt-5">
                        <PopulerLoans></PopulerLoans>

                    </div>
                    <div className="d-none d-lg-block d-md-block col-12 col-md-6 col-lg-6 mt-5 row justify-content-center  align-content-center">
                        <LoanRate></LoanRate>
                        {/* <div className="col-12 justify-content-center row">
                            <h3> <b>Ne Kadar Kredi Çekmeliyim ?</b></h3>
                            <p style={{ color: "black" }}>Artık hesap kitap işlerini sizin yerinize biz yapıyoruz. <br></br> Bize gereken birkaç gelir ve gider bilginiz. Deneyimli finans ve yazılım uzmanlarımızla geliştirdiğimiz hesap araçlarıyla, sizi hesap makinesinden kurtarıyoruz. </p>
                            <b className="mb-3" style={{ color: "black" }}>Aylık Gelirinizi Girerek Hesaplamaya Başlayın </b>
                            <div style={{ clear: "both" }}></div>
                            <div className="col-8">
                                <KrediInput style={{ width: "100%", maxWidth: "100%" }} placeholder="Tutar Giriniz" className="col-7"
                                    decimalSeparator=","
                                    thousandSeparator="."
                                    precision="0"
                                     onChange={(x) => { setHowMuchCalculate(x.replace(/\./g))}}
                                    value={howMuchCalculate}

                                    prefix="₺"
                                />
                                <button className="default-button mt-3" type="submit">HESAPLAMAYA BAŞLA</button>

                            </div>

                        </div>
 */}

                    </div>
                </div>

            </div>

        </div>
    )
}

const getContent = (data) => {
    if (data.includes("kobi")) {

        return (
            <>
                <Helmet>
                    <meta property="og:type" content="article" />
                    <meta property="og:title" content="Kobi Kredisi Hesaplama Ve Başvurma" />
                    <meta property="og:url" content={window.location.href} />
                    <meta property="og:description" content="Anlaşmalı olduğumuz bankaların içinden onlarca kobi kredisi seçeneğini sizin için hesaplayıp getiriyoruz" />
                    <meta name="keyword" content="kobi kredisi, kobi kredi başvurusu, kobi kredisi hesablama " />
                    <meta name="og:keyword" content="kobi kredisi, kobi kredi başvurusu, kobi kredisi hesablama " />

                    <meta name="twitter:title" content="Kobi Kredisi Hesaplama Ve Başvurma" />
                    <meta name="twitter:description" content="Anlaşmalı olduğumuz bankaların içinden onlarca kobi kredisi seçeneğini sizin için hesaplayıp getiriyoruz" />
                    <meta name="description" content="Anlaşmalı olduğumuz bankaların içinden onlarca kobi kredisi seçeneğini sizin için hesaplayıp getiriyoruz" />
                    <meta name="robots" content="index,follow" />
                    <title>{"Kobi Kredisi Hesaplama Ve Başvurma | kredi.com.tr"} </title>
                </Helmet>

                <div className="col-12 col-md-5 col-lg-5 row  align-content-center justify-content-center">
                    <div className="justify-content-center col-12 row">
                        <Image title="kobi kredisi arama ve başvuru kredi.com.tr" alt={"kobi kredisi başvuru"} style={{ width: "30%" }}
                            webp={require("../assets/images/corporatecolor.webp").default}
                            src={require("../assets/images/corporatecolor.png").default}></Image>
                    </div>
                    <div className="justify-content-center col-12 row">
                        <h2><b>Kobi Kredisi</b></h2>

                    </div>
                </div>
                <div className="col-12 col-md-7 col-lg-7 row justify-content-center d-none d-lg-block d-md-block">
                    <h2>
                        <b style={{ color: "rgb(61 61 61)" }}>Ara, Hesapla, Başvur!</b>
                    </h2>
                    <p style={{ color: "rgb(61 61 61)" }}>  Anlaşmalı olduğumuz bankaların içinden onlarca kobi kredisi seçeneğini sizin için hesaplayıp getirelim. </p>
                    <p style={{ color: "rgb(61 61 61)" }}>  Önceliğimiz düşük faiz oranı ile yüksek kredi alma şansı sağlamak. </p>
                </div>
            </>
        )
    } else if (data.includes("tasit")) {
        return (<>

            <Helmet>
                <meta property="og:type" content="article" />
                <meta property="og:title" content="Araç Kredisi Hesaplama Ve Başvurma" />
                <meta property="og:url" content={window.location.href} />
                <meta property="og:description" content="Hayalinizdeki aracı almak için krediye ihtiyaç duyuyorsanız, doğru yerdesiniz. Sizin için birçok fırsat bulabiliriz." />
                <meta name="keyword" content="araç kredisi, araç kredi başvurusu, araç kredisi hesablama " />
                <meta name="og:keyword" content="araç kredisi, araç kredi başvurusu, araç kredisi hesablama " />

                <meta name="twitter:title" content="Araç Kredisi Hesaplama Ve Başvurma" />
                <meta name="twitter:description" content="Hayalinizdeki aracı almak için krediye ihtiyaç duyuyorsanız doğru yerdesiniz. Sizin için birçok fırsat bulabiliriz." />
                <meta name="description" content="Hayalinizdeki aracı almak için krediye ihtiyaç duyuyorsanız doğru yerdesiniz. Sizin için birçok fırsat bulabiliriz." />
                <meta name="robots" content="index,follow" />
                <title>{"Kobi Kredisi Hesaplama Ve Başvurma | kredi.com.tr"} </title>
            </Helmet>
            <div className="col-12 col-md-5 col-lg-5 row  align-content-center justify-content-center">
                <div className="justify-content-center col-12 row">
                    <Image title="araç kredisi başcuruları kredi.com.tr" alt={"araç kredisi başvuru ve arama"} style={{ width: "30%" }}
                        webp={require("../assets/images/carColor.webp").default} src={require("../assets/images/carColor.png").default}></Image>
                </div>
                <div className="justify-content-center col-12 row">
                    <h3><b>Araç Kredisi.</b></h3>

                </div>
            </div>
            <div className="col-12 col-md-7 col-lg-7 row justify-content-center d-none d-lg-block d-md-block">
                <h2>
                    <b style={{ color: "rgb(61 61 61)" }}>Araç Kredini Hesapla!</b>
                </h2>
                <p style={{ color: "rgb(61 61 61)" }}>  Hayalinizdeki aracı almak için krediye ihtiyaç duyuyorsanız doğru yerdesiniz. Sizin için birçok fırsat bulabiliriz. </p>
                <p style={{ color: "rgb(61 61 61)" }}>  Aracınızı şimdiden seçin. Krediyi bulma işi ise bizde. </p>
            </div>
        </>)
    } else if (data.includes("konut")) {
        return (<>

            <Helmet>
                <meta property="og:type" content="article" />
                <meta property="og:title" content="Konut Kredisi Hesaplama Ve Başvurma" />
                <meta property="og:url" content={window.location.href} />
                <meta property="og:description" content="Hayalini kurduğunuz yuvaya kavuşurken çorbada bizim de tuzumuz olsun. Kredinizi bulmanıza yardım edelim." />
                <meta name="og:keyword" content="konut kredisi, konut kredi başvurusu, konut kredisi hesablama " />

                <meta name="keyword" content="konut kredisi, konut kredi başvurusu, konut kredisi hesablama " />
                <meta name="twitter:title" content="Konut Kredisi Hesaplama Ve Başvurma" />
                <meta name="twitter:description" content="Hayalini kurduğunuz yuvaya kavuşurken çorbada bizim de tuzumuz olsun. Kredinizi bulmanıza yardım edelim." />
                <meta name="description" content="Hayalini kurduğunuz yuvaya kavuşurken çorbada bizimde tuzumuz olsun. Kredinizi bulmanıza yardım edelim." />
                <meta name="robots" content="index,follow" />
                <title>{"Konut Kredisi Hesaplama Ve Başvurma | kredi.com.tr"} </title>
            </Helmet>
            <div className="col-12 col-md-5 col-lg-5 row  align-content-center justify-content-center">
                <div className="justify-content-center col-12 row">
                    <Image title="konut kredisi aramaları, başvurularu kredi.com.tr" alt={"konut kredi arama"} style={{ width: "30%" }}
                        webp={require("../assets/images/homecolor.webp").default}
                        src={require("../assets/images/homecolor.png").default}></Image>
                </div>
                <div className="justify-content-center col-12 row">
                    <h3><b>Konut Kredisi</b></h3>

                </div>
            </div>
            <div className="col-12 col-md-7 col-lg-7 row justify-content-center d-none d-lg-block d-md-block">
                <h2>
                    <b style={{ color: "rgb(61 61 61)" }}>Konut Kredinizi Aratın!</b>
                </h2>
                <p style={{ color: "rgb(61 61 61)" }}>  Hayalini kurduğunuz yuvaya kavuşurken çorbada bizim de tuzumuz olsun. Kredinizi bulmanıza yardım edelim. </p>
                <p style={{ color: "rgb(61 61 61)" }}>  Ev için krediyi sizin için buluyoruz. </p>
            </div>
        </>)
    } else if (data.includes("ihtiyac")) {
        return (<>
            <Helmet>
                <meta property="og:type" content="article" />
                <meta property="og:title" content="İhtiyaç Kredisi Hesaplama Ve Başvurma" />
                <meta property="og:url" content={window.location.href} />
                <meta property="og:description" content="İhtiyaç kredisi hayatın her anında lazım olan bir bir kredi türüdür. Bu krediyi bulmak ise kredi.com.tr olarak bizlerin uzmanlık alanıdır." />
                <meta name="keyword" content="ihtiyaç kredisi, ihtiyaç kredi başvurusu, ihtiyaç kredisi hesablama " />
                <meta name="og:keyword" content="ihtiyaç kredisi, ihtiyaç kredi başvurusu, ihtiyaç kredisi hesablama " />

                <meta name="twitter:title" content="İhtiyaç Kredisi Hesaplama Ve Başvurma" />
                <meta name="twitter:description" content="İhtiyaç kredisi hayatın her anında lazım olan bir bir kredi türüdür. Bu krediyi bulmak ise kredi.com.tr olarak bizlerin uzmanlık alanıdır." />
                <meta name="description" content="İhtiyaç kredisi hayatın her anında lazım olan bir bir kredi türüdür. Bu krediyi bulmak ise kredi.com.tr olarak bizlerin uzmanlık alanıdır." />
                <meta name="robots" content="index,follow" />
                <title>{"İhtiyaç Kredisi Hesaplama Ve Başvurma | kredi.com.tr"} </title>
            </Helmet>
            <div className="col-12 col-md-5 col-lg-5 row  align-content-center justify-content-center">
                <div className="justify-content-center col-12 row">
                    <Image title="ihtiyaç kredisi arama,sorgulama ve bulma kredi.com.tr" alt={"ihtiyaç kredisi sorgulama"} style={{ width: "30%" }}
                        webp={require("../assets/images/moneycolor.webp").default}
                        src={require("../assets/images/moneycolor.png").default}></Image>
                </div>
                <div className="justify-content-center col-12 row">
                    <h3><b>İhtiyaç Kredisi</b></h3>

                </div>
            </div>
            <div className="col-12 col-md-7 col-lg-7 row justify-content-center d-none d-lg-block d-md-block">
                <h2>
                    <b style={{ color: "rgb(61 61 61)" }}>İhtiyacınızı Karşılayın!</b>
                </h2>
                <p style={{ color: "rgb(61 61 61)" }}>  İhtiyaç kredisi hayatın her anında lazım olan bir kredi türüdür. Bu krediyi bulmak ise kredi.com.tr olarak bizlerin uzmanlık alanıdır. </p>
                <p style={{ color: "rgb(61 61 61)" }}> Ne zaman ihtiyaç duyarsanız, ihtiyaç kredinizi bulmaya hazırız. </p>
            </div>
        </>)
    }
}

export default Loan;