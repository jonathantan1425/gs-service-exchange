import Navbar from "../../../components/index/navbar";
import FinancialData from "../../../components/Financial-data/FinancialData";
import FinancialSidebar from "../../../components/Financial-data/FinancialSiderbar";

const index = () => {
  return (
    <div>
      <Navbar />
      <div className="flex">
        <FinancialSidebar />
        <FinancialData />
      </div>
    </div>
  );
};

export default index;
