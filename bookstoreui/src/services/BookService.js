import axios from 'axios';
const getAllBooksURL = 'https://localhost:44303/api/BookStore/GetALLBooks';

export const getAllBooksRequestMethod= async ()=>{
    const response = await axios.get(getAllBooksURL);
    return response;
}