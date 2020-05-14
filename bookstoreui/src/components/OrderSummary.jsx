import React, { Component } from 'react';
import { Typography, Button } from '@material-ui/core';
import orderImage from '../assets/ordersuccessful.jpg'

class OrderSummary extends Component {
    render() {
        return (
            <div className='order-main-div'>
                <Typography variant='h3'>Order Placed Successfully</Typography>
                <div className='order-image-div'>
                <img className='img' id='img' src={orderImage}/>
                </div>
                <p><b>Hurray!! your order is confirmed ,<br />
                the order id is #12112 save the order id for<br />
                further communication...</b></p>
                <div className='order-summary-table-div'>
                    <table class="table table-bordered">
                        <thead>
                            <tr>
                                <th>Email us</th>
                                <th>Contact us</th>
                                <th>Address</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>admin@bookstore.in</td>
                                <td>7000709194</td>
                                <td>1654/A,Shobha happy homes,<br /> 24th main, 2nd stage,HSR Layout</td>
                            </tr>
                        </tbody>
                    </table>          
                </div>
                <Button variant='outlined' color='primary'>Continue Shopping</Button>
            </div>
        )
    }
}
export default OrderSummary;