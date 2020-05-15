import axios from 'axios'
const loginURL='https://localhost:44303/api/Login/Login';

export const LoginRequestMethod = async (data)=>{
    const response = await axios.post(loginURL,data);
    return response;
}