import { useState, useEffect, useRef } from 'react'
import Script from 'next/script'
import { suggestions } from './constants';

const FinancialDataOptionsBar = (props) => {

  const [stock, setStock] = useState();
  const [showSuggestions, setShowSuggestions] = useState(false);
  const [securityType, setSecurityType] = useState("");
  const [timeRange, setTimeRange] = useState("");
  const [suggestion, setSuggestions] = useState([]);

  function filterStockOptions(value){
    setStock(value);
    let userData = value;
    const searchWrapper = document.querySelector(".search-input");
    var array = [];
    if (userData){
      array = suggestions[securityType].filter((data)=>{
        return data.toLocaleLowerCase().startsWith(userData.toLocaleLowerCase())
      })
      // array = array.map((data)=>{
      //   return `<li onclick="setStockName('${data}')" style="cursor:pointer;">` + data + `</li>`;
      // })
    }
    checkToShowSuggestions(array);
  }

  function setStockName(name){
    setStock(name);
  }

  function checkToShowSuggestions(list){
    const suggBox = document.getElementById("box")
    let listData;
    if (list.length <= 0){
      setShowSuggestions(false);
    } else {
      setShowSuggestions(true);
      setSuggestions(previous => [...list])
    }
  }

  function search(){
    const data = [stock, securityType, timeRange]

    props.parentCallback(data);
  }

  return (
    <div className='w-full flex justify-between mt-5' style={{zIndex: '1'}}>
      <div>
        <div className="block text-gray-700 text-sm font-bold my-auto" htmlFor="password">
          Securities Type
        </div>
        <select id="countries" className="rounded-lg w-full p-2.5 border shadow-xl" onChange={({target})=>setSecurityType(target?.value)}>
          <option selected>Choose the securities</option>
          <option value="TIME_SERIES">Equities</option>
          <option value="FX">Forex</option>
          <option value="DIGITAL_CURRENCY">Crypto</option>
        </select>
      </div>
      
      <div className='wrapper'>
        <div className="block text-gray-700 text-sm font-bold my-auto" htmlFor="password">
          Search Bar
        </div>
        <div className={showSuggestions ? 'search-input active' : 'search-input'}>
          <input type="text" id="stock" placeholder='Type to search..' value={stock} onKeyUp={({target})=>filterStockOptions(target?.value)}/>
          <div className='autocom-box' id="box">
            {
              suggestion.map((data, key)=>{
                return (<li key={key} onClick={()=>setStockName(data)} value={data} style={{cursor:'pointer'}}>{data}</li>)
              })
            }
          </div>
          <div className='icon'><i className='fas fa-search'></i></div>
        </div>
      </div>

      <div>
        <div className="block text-gray-700 text-sm font-bold my-auto" htmlFor="password">
          Time In
        </div>
        <select id="countries" className="rounded-lg w-full p-2.5 border shadow-xl" onChange={({target})=>setTimeRange(target?.value)}>
          <option selected>Choose the time in</option>
          <option value="DAILY">Daily</option>
          <option value="WEEKLY">Weekly</option>
          <option value="MONTHLY">Monthly</option>
        </select>
      </div>
      
      <div className="my-auto mt-5">
        <button onClick={()=>search()} className="w-full rounded border border-black p-2 shadow-xl font-bold text-black hover:bg-blue-700">
          Add Widget
        </button>
      </div>
    </div>
  )
}

export default FinancialDataOptionsBar