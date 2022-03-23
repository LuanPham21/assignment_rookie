import React, { useEffect, useState } from "react";
import { Button, Table } from "semantic-ui-react";
import { update, getobject } from "../../services/productService";
import { Link } from "react-router-dom";
export default function Update(props) {
  const { id } = props.match.params;
  const [product, setProduct] = useState({
    name: "",
    originalPrice: "",
    description: "",
    status: "",
    viewCount: "",
    details: "",
    price: "",
    ThumnailImage: null,
  });
  useEffect(() => {
    const data = getobject(id).then((res) => setProduct(res));
  }, []);
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
    console.log(product);
    var bodyFormData = new FormData();
    bodyFormData.append("Name", product.name);
    bodyFormData.append("Quantity", product.quantity);
    bodyFormData.append("OriginalPrice", product.originalPrice);
    bodyFormData.append("Description", product.description);
    bodyFormData.append("Status", product.status);
    bodyFormData.append("Details", product.details);
    bodyFormData.append("Price", product.price);
    bodyFormData.append("ThumnailImage", product.ThumnailImage);
    bodyFormData.append("Id", product.id);
    const response = await update(bodyFormData);
    console.log(response);
  };

  return (
    <div>
      <h1 className="text-center text-uppercase">
        <Link to={`/product`} className="category-link">
          <Table.Cell>
            <Button className="btn btn-primary ">
              <i class="fas fa-arrow-left btn-back"></i>
            </Button>
          </Table.Cell>
        </Link>
        Update Product
      </h1>
      <div className="container">
        <div className="row category-row ">
          <div className="col-lg-10">
            <div class="card">
              <div class="card-body">
                <div class="form-group">
                  <label>Name</label>
                  <input
                    placeholder="Name"
                    value={product.name}
                    name="name"
                    onChange={handleChange}
                    class="form-control"
                  />
                  <label>Original Price</label>
                  <input
                    placeholder="OriginalPrice"
                    value={product.originalPrice}
                    name="originalPrice"
                    onChange={handleChange}
                    class="form-control"
                  />
                  <label>Price</label>
                  <input
                    placeholder="Price"
                    value={product.price}
                    name="price"
                    onChange={handleChange}
                    class="form-control"
                  />
                  <label>Description</label>
                  <textarea
                    placeholder="Description"
                    value={product.description}
                    name="description"
                    onChange={handleChange}
                    class="form-control"
                    rows="3"
                  ></textarea>
                  <label>Status</label>
                  <select name="cars" class="custom-select">
                    <option
                      value={(product.status = 0)}
                      name="status"
                      class="custom-select"
                      onChange={handleChange}
                    >
                      InActive
                    </option>
                    <option
                      value={(product.status = 1)}
                      name="status"
                      onChange={handleChange}
                    >
                      Active
                    </option>
                  </select>
                  <label>Details</label>
                  <textarea
                    placeholder="Details"
                    value={product.details}
                    name="details"
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
                  <Link to={`/product`} className="category-link">
                    <Table.Cell>
                      {/* <Button className="btn btn-primary ">
              <i class="fas fa-arrow-left btn-back"></i>
            </Button> */}
                      <button
                        class="btn btn-success mt-3"
                        onClick={btnOnClick}
                        type="submit"
                      >
                        Submit
                      </button>
                    </Table.Cell>
                  </Link>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}
