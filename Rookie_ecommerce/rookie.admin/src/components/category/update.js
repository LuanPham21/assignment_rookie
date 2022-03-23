import React, { useEffect, useState } from "react";
import { Button, Table } from "semantic-ui-react";
import { update, getobject } from "../../services/cateService";
import { Link } from "react-router-dom";

export default function Update(props) {
  const { id } = props.match.params;
  const [cate, setCate] = useState({
    name: "",
    parentId: "",
    status: "",
  });
  useEffect(() => {
    const data = getobject(id).then((res) => setCate(res));
  }, []);
  const handleChange = (e) => {
    const { name, value } = e.target;
    setCate((prevState) => ({
      ...prevState,
      [name]: value,
    }));
  };

  const btnOnClick = async () => {
    console.log(cate);
    var bodyFormData = new FormData();
    bodyFormData.append("Name", cate.name);
    bodyFormData.append("ParentId", cate.parentId);
    bodyFormData.append("Status", cate.status);
    bodyFormData.append("Id", cate.id);

    const response = await update(bodyFormData);
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
        Edit Category
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
                    value={cate.name}
                    name="name"
                    onChange={handleChange}
                    className="input-category"
                    class="form-control"
                  />
                  <label>ParentId</label>
                  <input
                    type="text"
                    placeholder="ParentId"
                    value={cate.parentId}
                    name="parentId"
                    onChange={handleChange}
                    className="input-category"
                    class="form-control"
                  />
                  <label>Status</label>
                  <select name="cars" class="custom-select">
                    <option
                      value={(cate.status = 0)}
                      name="status"
                      onChange={handleChange}
                    >
                      InActive
                    </option>
                    <option
                      value={(cate.status = 1)}
                      name="status"
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
