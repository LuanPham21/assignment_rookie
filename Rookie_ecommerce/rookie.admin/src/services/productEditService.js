import axios from "axios";
export const updateProduct = async () => {
    const endpoint = "https://localhost:5000/api/Products";
    const response = await axios.post(endpoint)
    return response
};
