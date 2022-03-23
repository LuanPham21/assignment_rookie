import React, { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import Update  from "../components/Product/update";
import { getProduct } from "../../services/productService";
import { Table } from 'semantic-ui-react'
import { Button} from 'semantic-ui-react'
const Product = (props) => {
  const showdata = (data) => {
    console.log(data);
 }
  // const [APIData, setAPIData] = useState([]);
  // useEffect(() => {
  //   axios.get(`https://localhost:5000/api/Products`)
  //   .then((response) => {
  //       setAPIData(response.data);
  //   })
  // }, [])
    const [data,setData] =useState();
    useEffect(async()=>{
        const data = await getProduct().then(res=>setData(res)) 
    },[])
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
                
                {/* <Link to={`/update/${d.id}`} element={<Update/>}>Update</Link> */}
                <Link to={"/update"} element={<Update/>} onClick={() => showdata(d)}>
                <Table.Cell> 
                  <Button>Update</Button>
                </Table.Cell>
                </Link>
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