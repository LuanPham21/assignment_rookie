import axios from "axios";
export const getProduct = async () => {
    const endpoint = "https://localhost:5000/api/Products";
    const response = await axios.get(endpoint)
    return response
};
