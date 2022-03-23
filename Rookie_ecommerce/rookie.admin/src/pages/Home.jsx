import { Link  } from "react-router-dom";
import Product from "../pages/Product";
import Category from "../pages/Category";
const Home = (props) => {
  return (
    <>
      <div className="container">
        <div className="row">
          <h1 className="text-center">Welcome to Admin</h1>
        </div>
      </div>
      <div className="container mt-3">
        <div className="row ">
          <div className="col-lg-6 text-right">
            <Link to="/product" element={<Product/>} className="btn btn-primary">Product</Link>
          </div>
          <div className="col-lg-6  text-left">
            <Link to="/category" element={<Category/>} className="btn btn-info">Category</Link>

          </div>
        </div>
      </div>
    </>
  );
};

export default Home;