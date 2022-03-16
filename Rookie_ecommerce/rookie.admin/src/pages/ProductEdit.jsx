import React, { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import { getProduct } from "../services/productService";
const Product = (props) => {
    const [data, setData] = useState({});
    useEffect(() => {
      (async () => {
        setData(await getProduct());
      })();
    }, []);
    return (
      <>
        {/* <pre>{JSON.stringify(data)}</pre> */}
      </>
    );
  };
  
export default Product;