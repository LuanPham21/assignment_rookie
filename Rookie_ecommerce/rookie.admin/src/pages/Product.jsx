import React, { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import { getProduct } from "../services/productService";
const Product = (props) => {
    const [data,setData] =useState();
    useEffect(async()=>{
        const data = await getProduct().then(res=>setData(res)) 
    },[])
    console.log(data);
    return (
      <>
        <table id="table">
          <thead>
            <tr>
              <th>Id</th>
              <th>Name</th>
              <th>Quantity</th>
              <th>OriginalPrice</th>
              <th>Price</th>
              <th></th>
            </tr>
          </thead>
          <tbody>
            {data?data.data.map((d) => (
              <tr key={d.id}>
                <td>{d.id}</td>
                <td>{d.name}</td>
                <td>{d.quantity}</td>
                <td>{d.originalPrice}</td>
                <td>{d.price}</td>
                <Link to={`/Delete/${d.id}`}>Delete</Link>
                <Link to={`/Edit/${d.id}`}>Edit</Link>
                <td>
                </td>
              </tr>
            )):<></>}
          </tbody>
        </table>
        {/* <pre>{JSON.stringify(data)}</pre> */}
      </>
    );
  };
  
export default Product;