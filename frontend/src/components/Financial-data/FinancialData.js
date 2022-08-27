import React, { useState } from "react";
import FinancialDataOptionsBar from "./FinancialDataOptionsBar";
import FinancialWidget from './FinancialWidget'

const FinancialData = () => {

  const [financialWidget, setFinancialWidget] = useState([
    [
      'AMZN',
      'TIME_SERIES',
      'DAILY'
    ]
  ]);

  function handleCallback(data){
    setFinancialWidget(previousWidgets => [...previousWidgets, data]);
  }

  return (
            <div className="container mx-auto px-4 w-full">
              <FinancialDataOptionsBar parentCallback = {handleCallback} />
              <div className="grid xl:grid-cols-2 grid-cols-1 gap-4 mt-8" style={{zIndex: '-1'}}>
                {
                  financialWidget.map((data, key)=>{
                    return (<FinancialWidget className="mb-4" key={key} data={data} />)
                  })
                }
            </div>
            </div>
        );
};

export default FinancialData;
