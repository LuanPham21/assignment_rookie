import axios from "axios";
export const getProduct = async () => {
    const endpoint = "https://localhost:5000/api/Products";
    const response = await axios.get(endpoint)
    return response
};
export const add = async(props)=>{
    const res = await axios.post(`https://localhost:5000/api/Products`,props,{})
    return res
}
export const getobject = async(props)=>{
    const res = await axios.get(`https://localhost:5000/api/Products/${props}`)
    return res.data
}
export const update = async(props)=>{
    const res = await axios.put(`https://localhost:5000/api/Products`,props,{})
    return res
}