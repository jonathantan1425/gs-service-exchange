import React, { useEffect, useState } from 'react'
import { Line } from 'react-chartjs-2'
import Chart from 'chart.js/auto'

const FinancialWidget = (props) => {

  const API_KEY = "ZXC9PLPBQPNDW0GR"
  
  const [chartXvalues, setChartXvalues] = useState([]);
  const [chartYvalues, setChartYvalues] = useState([]);
  const [label, setLabel] = useState();
  const stock = props.data[0];
  const securityType = props.data[1];
  const timeRange = props.data[2];

  useEffect(()=>{
    let url = "";
    if (securityType == "FX"){
      url = `https://www.alphavantage.co/query?function=FX_${timeRange}&from_symbol=${stock}&to_symbol=USD&outputsize=compact&apikey=${API_KEY}`;
      setLabel(`Forex: ${timeRange} range of ${stock} to USD`)
    } else if (securityType == "DIGITAL_CURRENCY"){
      url = `https://www.alphavantage.co/query?function=DIGITAL_CURRENCY_${timeRange}&symbol=${stock}&market=USD&outputsize=compact&apikey=${API_KEY}`;
      setLabel(`Cryptocurrency: ${timeRange} range of ${stock}`)
    } else {
      url = `https://www.alphavantage.co/query?function=TIME_SERIES_${timeRange}&symbol=${stock}&outputsize=compact&apikey=${API_KEY}`;
      setLabel(`Equity ${timeRange} range of ${stock}`)
    }
    
    let yValues = [];
    let xValues = [];
    fetch(url)
      .then(
        function(response){
          return response.json();
        }
      )
      .then(data =>{
        const getDataKey = Object.keys(data)[1]
        for (var key in data[getDataKey]) {
          xValues.push(key);
          yValues.push(data[getDataKey][key]["1. open"])
        }

        setChartXvalues(xValues);
        setChartYvalues(yValues);
      })
  }, [])

  return (
    <div className="rounded-lg border border-black text-center p-4">
      <Line
      datasetIdKey='id'
      data={{
        labels: chartXvalues,
        datasets: [
          {
            label: label,
            id: 1,
            data: chartYvalues,
            borderColor: 'rgb(75, 192, 192)',
          }
        ],
      }}
    />
    </div>
  )
}

export default FinancialWidget