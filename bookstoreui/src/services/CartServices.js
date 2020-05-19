import axios from 'axios'

const addCartURL = 'https://localhost:5001/api/Cart/AddCart';
const cartAddedCountURL = 'https://localhost:5001/api/Cart/CountCart';
const getCartValuesURL = 'https://localhost:5001/api/Cart/GetAllCartValue';
const deleteCartValueURL = 'https://localhost:5001/api/Cart/DeleteCart';
const addCustomerDetailsURL = 'https://localhost:5001/api/Address/AddDetailAddress';
const getCustomerAddressURL = 'https://localhost:5001/api/Address/GetCustomerAddress';

export const AddCartRequestMethod = async (data)=>{
    const response = await axios.post(addCartURL,data);
    return response;
}

export const getCartAddedCountRequestMethod= async ()=>{
    const response = await axios.get(cartAddedCountURL);
    return response;
}

export const getCartValuesRequestMethod= async ()=>{
    const response = await axios.get(getCartValuesURL);
    return response;
}

export const deleteCartValueRequestMethod= async (id)=>{
    const response = await axios.delete(deleteCartValueURL,id);
    return response;
}

export const addCustomerDetailsRequestMethod = async (data)=>{
    const response = await axios.post(addCustomerDetailsURL,data);
    return response;
}

export const getCustomerAddressRequestMethod = async (data)=>{
    const response = await axios.get(getCustomerAddressURL,{ params: {email: data}});
    return response;
}
