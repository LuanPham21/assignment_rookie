import { Link  } from "react-router-dom";
import Create from "../components/Product/create";
const Home = (props) => {
  return (
    <>
      <h1>This is Home page</h1>
      <Link to="/product">Click here to show product api</Link>
      <Link to="/create" element={<Create/>}>Create</Link>
    </>
  );
};

export default Home;