import { Collapse } from "reactstrap"
import React, { useEffect, useState } from "react"
import { apiurl, GetNoneToken } from "../datacrud/datacrud"
import ArrowDropDownIcon from '@material-ui/icons/ArrowDropDown';
import ArrowDropUpIcon from '@material-ui/icons/ArrowDropUp';
import Rimage from "../Components/Rimage";
 const Faq = () => {
    const [data, setData] = useState([])
    const [openId, setOpenId] = useState("")
    const [blog, setBlog] = useState([]);

    useEffect(() => {
        start()
    }, [])
    const start = async () => {
        let d = await GetNoneToken("Faqs/GetAllWebSiteFull").then(x => { return x.data }).catch(x => { return false })
        setData(d)
        let blogList = await GetNoneToken("Blogs/get4Blog").then(x => { return x.data }).catch(x => { return false })
        setBlog(blogList)

    }

    return (

        <div className="master-content">
            <p className="home-title text-center" >Aklınıza takılan  <span style={{ fontWeight: "bold" }}>soruları derleyip toparlayıp </span> sizin için cevapladık.</p>

            <div className="row">
                <div className="col-8 mt-5">
                    {
                        data?.map((item, key) => {
                            return (
                                <div key={key} className="col-12 row sss-item">
                                    <div className="col-12 row">
                                        <div className="col-10 sss-title">{item.question} </div>
                                        <div className="col-2">
                                            {
                                                openId != item.id &&
                                                <button style={{
                                                    border: "1px solid #c3c3c3",
                                                    borderRadius: 6,
                                                    float: "right"
                                                }} onClick={() => { setOpenId(item.id) }}> <ArrowDropDownIcon></ArrowDropDownIcon></button>

                                            }
                                            {
                                                openId == item.id &&
                                                <button style={{
                                                    border: "1px solid #c3c3c3",
                                                    borderRadius: 6,
                                                    float: "right"
                                                }} onClick={() => { setOpenId(null) }}> <ArrowDropUpIcon></ArrowDropUpIcon></button>

                                            }

                                        </div>

                                    </div>

                                    <Collapse className="sss-collapse" isOpen={item.id == openId}>
                                        {item.ansver}
                                    </Collapse>
                                </div>
                            )


                        })

                    }

                </div>
                <div className="col-4">
                <div className="mb-3 mt-2">Başlıca Haberler </div>
                <hr className="title-hr"></hr>
                {blog?.map((item, key) => {
                    return (
                        <div  key={key} className="col-12 row mb-3 blog-detail-item">

                            <div className="col-3 p-0">
                                <Rimage src={item.imageUrl} style={{ width: "100%" }}></Rimage>
                            </div>
                            <div  className="col-7 p-0 pl-2 pr-1" style={{ fontSize: 13, color: "black" }}>
                                {item.title}
                                <br></br>
                                <i style={{ color: "grey" }}>{item.date}</i>
                            </div>
                            <div  className="col-2 row p-0" style={{
                                justifyContent: "flex-end",
                                alignItems: "center"
                            }}>
                                <a href={"/haberler-bilgiler/"+item.urlName}><b>Oku</b></a>
                            </div>
                        </div>
                    )
                })}
                </div>
            </div>
        </div>
    )
}
export default Faq