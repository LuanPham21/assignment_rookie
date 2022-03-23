import React, { useState } from "react";
import { Button, Table, Form } from "semantic-ui-react";
import { add } from "../../services/productService";
import { Link } from "react-router-dom";
export default function Create() {
  const [product, setProduct] = useState({
    Name: "",
    Quantity: "",
    OriginalPrice: "",
    Price: "",
    Description: "",
    TimeCreate: new Date().toISOString(),
    Status: "",
    ViewCount: 0,
    Details: "",
    ThumnailImage: null,
  });
  const handleChange = (e) => {
    const { name, value } = e.target;
    setProduct((prevState) => ({
      ...prevState,
      [name]: value,
    }));
  };
  const handleChangeFile = (e) => {
    const { name, files } = e.target;
    setProduct((prevState) => ({
      ...prevState,
      [name]: files[0],
    }));
  };

  const btnOnClick = async () => {
    var bodyFormData = new FormData();
    bodyFormData.append("Name", product.Name);
    bodyFormData.append("Quantity", product.Quantity);
    bodyFormData.append("OriginalPrice", product.OriginalPrice);
    bodyFormData.append("Price", product.Price);
    bodyFormData.append("Description", product.Description);
    bodyFormData.append("TimeCreate", product.TimeCreate);
    bodyFormData.append("Status", product.Status);
    bodyFormData.append("ViewCount", product.ViewCount);
    bodyFormData.append("Details", product.Details);
    bodyFormData.append("ThumnailImage", product.ThumnailImage);
    const response = await add(bodyFormData);
    console.log(response);
  };

  return (
    <div>
      <h1 className="text-center mb-5 text-uppercase">
        <Link to={`/category`} className="category-link">
          <Table.Cell>
            <Button className="btn btn-primary ">
              <i class="fas fa-arrow-left btn-back"></i>
            </Button>
          </Table.Cell>
        </Link>
        Create Product
      </h1>
      <div className="container">
        <div className="row category-row ">
          <div className="col-lg-10">
            <div class="card">
              <div class="card-body">
                <div class="form-group">
                  <label>Name</label>
                  <input
                    type="text"
                    placeholder="Name"
                    value={product.Name}
                    name="Name"
                    onChange={handleChange}
                    className="input-category"
                    class="form-control"
                  />
                  <label>Original Price</label>
                  <input
                    placeholder="OriginalPrice"
                    value={product.OriginalPrice}
                    name="OriginalPrice"
                    onChange={handleChange}
                    class="form-control"
                  />
                  <label>Price</label>
                  <input
                    placeholder="Price"
                    value={product.Price}
                    name="Price"
                    onChange={handleChange}
                    class="form-control"
                  />
                  <label>Description</label>
                  <textarea
                    placeholder="Description"
                    value={product.Description}
                    name="Description"
                    onChange={handleChange}
                    class="form-control"
                    rows="3"
                  ></textarea>
                  <label>Quantity</label>
                  <input
                    type="text"
                    placeholder="Quantity"
                    value={product.Quantity}
                    name="Quantity"
                    onChange={handleChange}
                    className="input-category"
                    class="form-control"
                  />
                  <label>Status</label>
                  <select name="cars" class="custom-select">
                    <option
                      value={(product.Status = 0)}
                      name="Status"
                      onChange={handleChange}
                    >
                      InActive
                    </option>
                    <option
                      value={(product.Status = 1)}
                      name="Status"
                      onChange={handleChange}
                    >
                      Active
                    </option>
                  </select>
                  <label>Details</label>
                  <textarea
                    placeholder="Details"
                    value={product.Details}
                    name="Details"
                    onChange={handleChange}
                    class="form-control"
                    rows="3"
                  ></textarea>
                  <label>ThumbnailImage</label>
                  <input
                    type="file"
                    name="ThumnailImage"
                    height={150}
                    onChange={handleChangeFile}
                    class="form-control"
                  />
                </div>
                <button
                  onClick={btnOnClick}
                  type="submit"
                  class="btn btn-success mt-3"
                >
                  Submit
                </button>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}
