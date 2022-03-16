import axios from "axios";
export const createProduct = async () => {
    const endpoint = "https://localhost:5000/api/Products";
    const response = await axios.create(endpoint)
    return response
};