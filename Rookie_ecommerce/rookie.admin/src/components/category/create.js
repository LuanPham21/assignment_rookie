import React, { useState } from "react";
import { Table, Button, Form } from "semantic-ui-react";
import { add } from "../../services/cateService";
import { Link } from "react-router-dom";

export default function Create() {
  // const [Name, setName] = useState("");
  // const [Quantity, setQuantity] = useState('');
  // const [OriginalPrice, setOriginalPrice] = useState('');
  // const [Price, setPrice] = useState('');
  // const [Description, setDescription] = useState('');
  // // const [TimeCreate, setTimeCreate] = useState('');
  // const [Status, setStatus] = useState();
  // const [ViewCount, setViewCount] = useState('');
  // const [Details, setDetails] = useState('');
  // const [ThumnailImage, setThumbnailImage] = useState('');
  const [cate, setCate] = useState({
    Name: "",
    ParentId: "",
    Status: "",
  });
  const handleChange = (e) => {
    const { name, value } = e.target;
    setCate((prevState) => ({
      ...prevState,
      [name]: value,
    }));
  };

  const btnOnClick = async () => {
    var bodyFormData = new FormData();
    bodyFormData.append("Name", cate.Name);
    bodyFormData.append("ParentId", cate.ParentId);
    bodyFormData.append("Status", cate.Status);
    const response = await add(bodyFormData);
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
        Create Category
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
                    value={cate.Name}
                    name="Name"
                    onChange={handleChange}
                    className="input-category"
                    class="form-control"
                  />
                  <label>ParentId</label>
                  <input
                    type="text"
                    placeholder="ParentId"
                    value={cate.ParentId}
                    name="ParentId"
                    onChange={handleChange}
                    className="input-category"
                    class="form-control"
                  />
                  <label>Status</label>
                  <select name="cars" class="custom-select">
                    <option
                      value={(cate.Status = 0)}
                      name="Status"
                      onChange={handleChange}
                    >
                      InActive
                    </option>
                    <option
                      value={(cate.Status = 1)}
                      name="Status"
                      onChange={handleChange}
                    >
                      Active
                    </option>
                  </select>
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
