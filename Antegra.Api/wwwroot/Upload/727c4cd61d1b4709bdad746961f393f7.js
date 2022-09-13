import React, { useEffect } from 'react';


function Loading(props) {
    useEffect(() => {

        start()
    }, [])
    function start() {
       var pat= window.location.pathname.toString().split("/");
       
    }

    return (
        <div className="container">
            <div className="col-12 row">
                <img style={{
                    width: "50%",
                    margin: " 0 auto"
                }} src={require("../assets/images/loading.gif").default}></img>

            </div>
        </div>
    );
}

export default Loading;