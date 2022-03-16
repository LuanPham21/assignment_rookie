import React, { useState } from 'react';
import { Button, Checkbox, Form } from 'semantic-ui-react'
import axios from 'axios';
export default function Create() {
    const [Name, setName] = useState("");
    const [Quantity, setQuantity] = useState('');
    const [OriginalPrice, setOriginalPrice] = useState('');
    const [Price, setPrice] = useState('');
    const [Description, setDescription] = useState('');
    // const [TimeCreate, setTimeCreate] = useState('');
    const [Status, setStatus] = useState();
    const [ViewCount, setViewCount] = useState('');
    const [Details, setDetails] = useState('');
    const [thumnailImage, setThumbnailImage] = useState('');
    const postData = async () => {
         await axios.post("https://localhost:5000/api/Products", {
            Name,
            Quantity,
            OriginalPrice,
            Price,
            Description,
            TimeCreate:new Date().toISOString(),
            Status,
            ViewCount,
            Details,
            thumnailImage
        })       
    }
    return (
        <div>
            <Form className="create-form">
                <Form.Field>
                    <label>First Name</label>
                    <input placeholder='First Name' onChange={(e) => setName(e.target.value)}/>
                </Form.Field>
                <Form.Field>
                    <label>Quantity</label>
                    <input placeholder='Quantity' onChange={(e) => setQuantity(e.target.value)}/>
                </Form.Field>
                <Form.Field>
                    <label>OriginalPrice</label>
                    <input placeholder='OriginalPrice' onChange={(e) => setOriginalPrice(e.target.value)}/>
                </Form.Field>
                <Form.Field>
                    <label>Price</label>
                    <input placeholder='Price' onChange={(e) => setPrice(e.target.value)}/>
                </Form.Field>
                <Form.Field>
                    <label>Description</label>
                    <input placeholder='Description' onChange={(e) => setDescription(e.target.value)}/>
                </Form.Field>
                {/* <Form.Field>
                    <label>TimeCreate</label>
                    <input placeholder='TimeCreate' readonly onChange={(e) => setTimeCreate(e.target.value)}/>
                </Form.Field> */}
                <Form.Field>
                    <label>Status</label>
                    <select>
                        <option onChange={(e) => setStatus(e.target.value = 0)}>InActive</option>
                        <option onChange={(e) => setStatus(e.target.value = 1)}>Active</option>
                    </select>
                </Form.Field>
                <Form.Field>
                    <label>ViewCount</label>
                    <input placeholder='ViewCount' onChange={(e) => setViewCount(e.target.value)}/>
                </Form.Field>
                <Form.Field>
                    <label>Details</label>
                    <input placeholder='Details' onChange={(e) => setDetails(e.target.value)}/>
                </Form.Field>
                <Form.Field>
                    <label>ThumbnailImage</label>
                    <input type="file" onChange={(e) => setThumbnailImage(e.target.value)}/>
                </Form.Field>
                <Button onClick={postData} type='submit'>Submit</Button>
            </Form>
        </div>
    )
}