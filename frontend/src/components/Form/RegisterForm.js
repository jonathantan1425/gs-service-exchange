import React, {useEffect, useState} from 'react'
import axios from "axios"
import { useRouter } from "next/router";
import Link from 'next/link';

const LoginForm = () => {

  const [name, setName] = useState();
  const [email, setEmail] = useState();
  const [username, setUsername] = useState();
  const [password, setPassword] = useState()
  const [dob, setDob] = useState();
  const [address, setAddress] = useState();
  const [isError, setIsError] = useState(false);
  const [registerStatus, setRegisterStatus] = useState(false);
  const [isLoggedIn, setIsLoggedIn] = useState(false);



  async function Register(props){

    const router = useRouter()

    let data = {
      username: username,
      password: password,
      email: email,
      name: name,
      dob: dob.toString(),
      address: address,
    }

    await axios.post(process.env.NEXT_PUBLIC_API_URL + "/client", data, {headers: {
      'Content-Type': 'application/json',
      'accept': 'application/json'
    }})
    .then(res => {
      console.log(res);
      if (res.status == 200) {
        setRegisterStatus(true)
      }
    })
    .catch(err => console.log(err));


    let login_data = {
      username: username,
      password: password,
      user_type: "client"
    }

    await axios.post(process.env.NEXT_PUBLIC_API_URL + "/login/access-token", login_data, {headers: {
      'Content-Type': 'application/json',
      'accept': 'application/json'
    }})
    .then(res => {
      console.log(res);
      if (res.status == 200) {
        localStorage.setItem("ACCESS_TOKEN", res.data.access_token);
        router.push('/client')
      }
    })
    .catch(err => {
      console.log(err)
      setIsError(true);
    });


  }

  return (
    <div className="w-9/10 mx-auto">
      <h1 className="text-2xl text-white">Register</h1>
      <br />
      <form className="bg-white shadow-md rounded px-8 pt-6 pb-8 mb-4">
        <div className="mb-4">
        <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="name">
            Full Name
        </label>
        <input className="shadow appearance-none border bg-white rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" id="name" type="text" placeholder="Full Name" onChange={({target})=>setName(target?.value)}/>
        </div>
        <div className="mb-4">
        <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="email">
            Email
        </label>
        <input className="shadow appearance-none border bg-white rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" id="email" type="text" placeholder="Email" onChange={({target})=>setEmail(target?.value)} />
        </div>
        <div className="mb-4">
        <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="username">
            Username
        </label>
        <input className="shadow appearance-none border bg-white rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" id="username" type="text" placeholder="Username" onChange={({target})=>setUsername(target?.value)}/>
        </div>
        <div className="mb-4">
          <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="password">
              Password
          </label>
          <input className="shadow appearance-none border bg-white rounded w-full py-2 px-3 text-gray-700 mb-3 leading-tight focus:outline-none focus:shadow-outline" id="password" type="password" placeholder="******************" onChange={({target})=>setPassword(target?.value)}/>
        </div>
        <div className="mb-4">
          <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="password">
                Date of Birth
          </label>
          <div className="relative">
            <div className="flex absolute inset-y-0 left-0 items-center pl-3 pointer-events-none">
              <svg aria-hidden="true" className="w-5 h-5 text-gray-400" fill="currentColor" viewBox="0 0 20 20" xmlns="http://www.w3.org/2000/svg"><path fillRule="evenodd" d="M6 2a1 1 0 00-1 1v1H4a2 2 0 00-2 2v10a2 2 0 002 2h12a2 2 0 002-2V6a2 2 0 00-2-2h-1V3a1 1 0 10-2 0v1H7V3a1 1 0 00-1-1zm0 5a1 1 0 000 2h8a1 1 0 100-2H6z" clipRule="evenodd"></path></svg>
            </div>
            <input type="date" className="bg-white border border-gray-300 text-gray-400 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full pl-10 p-2.5 " placeholder="Select date" onChange={({target})=>setDob(target?.value)}/>
          </div>
        </div>
        <div className="mb-6">
        <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="address">
            Address
        </label>
      <input className="shadow appearance-none border bg-white rounded w-full py-2 px-3 text-gray-700 mb-3 leading-tight focus:outline-none focus:shadow-outline" id="password" type="text" placeholder="Address" onChange={({target})=>setAddress(target?.value)}/>
        </div>
        <div className="flex items-center justify-between mb-2">
            <button className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline" type="button" onClick={()=>Register()}>
                Register
            </button>
        </div>
        { isError ? <p className="text-red-500 text-xs italic">Please type in the correct username or password</p> : ''}
        <Link href="/login" className="text-blue-500 text-xs">Have an account? Login here</Link>
    </form>
    </div>
  )
}

export default LoginForm
