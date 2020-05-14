import axios from 'axios'

const addCartURL = 'https://localhost:44303/api/Cart/AddCart';
const cartAddedCountURL = 'https://localhost:44303/api/Cart/CountCart';
const getCartValuesURL = 'https://localhost:44303/api/Cart/GetAllCartValue';
const deleteCartValueURL = 'https://localhost:44303/api/Cart/DeleteCart';

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
