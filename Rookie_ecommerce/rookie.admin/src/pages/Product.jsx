import React, { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import { getProduct } from "../services/productService";
import { Table, Button } from "semantic-ui-react";
const Product = (props) => {
  const [data, setData] = useState();
  useEffect(async () => {
    const data = await getProduct().then((res) => setData(res));
  }, []);
  return (
    <>
      <h1 className="text-center mb-5 text-uppercase">
        <Link to={`/`} className="category-link">
          <Table.Cell>
            <Button className="btn btn-primary ">
              <i class="fas fa-arrow-left btn-back"></i>
            </Button>
          </Table.Cell>
        </Link>
        Product
      </h1>
      <div className="container mb-5">
        <div className="row category-row">
          <div className="col-lg-10">
            <Link to={`/addpro`}>
              <Table.Cell>
                <Button className="btn btn-primary">Add New Product</Button>
              </Table.Cell>
            </Link>
          </div>
        </div>
      </div>
      <div className="container">
        <div className="row category-row">
          <div className="col-lg-10">
            <table className="table table-hover table-border">
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
                {data ? (
                  data.data.map((d) => (
                    <tr key={d.id}>
                      <td>{d.id}</td>
                      <td>{d.name}</td>
                      <td>{d.quantity}</td>
                      <td>{d.originalPrice}</td>
                      <td>{d.price}</td>
                      <td>
                        <Link to={`/editpro/${d.id}`}>
                          <Table.Cell>
                            <Button className="btn btn-warning">
                              <i class="fas fa-edit"></i>
                            </Button>
                          </Table.Cell>
                        </Link>
                      </td>
                    </tr>
                  ))
                ) : (
                  <></>
                )}
              </tbody>
            </table>
          </div>
        </div>
      </div>

      {/* <pre>{JSON.stringify(data)}</pre> */}
    </>
  );
};

export default Product;
