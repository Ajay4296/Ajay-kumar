import axios from 'axios';
const getAllBooksURL = 'https://localhost:44303/api/BookStore/GetALLBooks';
const getBookCOuntURL = 'https://localhost:44303/api/BookStore/CountBook';

export const getAllBooksRequestMethod= async ()=>{
    const response = await axios.get(getAllBooksURL);
    return response;
}

export const getBookCountRequestMethod= async ()=>{
    const response = await axios.get(getBookCOuntURL);
    return response;
}