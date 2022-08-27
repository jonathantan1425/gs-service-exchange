import Navbar from "../components/index/navbar";
import Footer from "../components/index/footer";
import Hero from "../components/index/hero";
import Products from "../components/index/products";
import InstitutionalServices from "../components/index/institutionalServices";
import BankingServices from "../components/index/bankingServices";
import axios from 'axios';

export async function getStaticProps() {
  const marketplaceData = await axios.get('https://api.gsserviceexchange.online/api/Solution', {
    headers: {
      'Content-Type': 'application/json',
      'Accept': 'application/json',
      'Authorization': 'Bearer ' + process.env.ACCESS_TOKEN
    }
  }).then(res => {
      return res.data;
    }).catch(err => {
      console.log(err);
    }
  );

  return {
    props: {
      marketplaceData
    }, // will be passed to the page component as props
  }
}

export default function Home({ marketplaceData }) {
  return (
    <>
      <Navbar/>
      <div className="divide-y divide-solid divide-grey_200">
        <Hero/>
        <Products productData={marketplaceData}/>
        <InstitutionalServices institutionalData={marketplaceData}/>
        <BankingServices bankingData={marketplaceData}/>
      </div>
      <Footer/>
    </>
  )
}
