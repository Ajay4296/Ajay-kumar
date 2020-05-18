import React, { Component } from 'react';
import { Typography, Button } from '@material-ui/core';
import orderImage from '../assets/ordersuccessful.jpg';
import {withRouter } from 'react-router-dom';

class OrderSummary extends Component {
    constructor(props)
    {
        super(props)
        this.state={
        }
    
    }
    
    continueShoppingHandler=()=>{
        console.log('inside continue');
        //this.props.history.push('/Dashboard');
        window.location.reload();
    }
    render() {
        return (
            <>
                <div className='order-main-div'>
                <Typography id='order-summary-title' variant='h3'>Order Placed Successfully</Typography>
                <div className='order-image-div'>
                <img className='img' id='img-ordersummary' src={orderImage}/>
                </div>
                <p><b>Hurray!! your order is confirmed ,<br />
                the order id is #{this.props.orderID} save the order id for<br />
                further communication...</b></p>
                <div className='table-responsive' id='table-div'>
                    <table class=" table table-bordered" id='address-table'>
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
                <Button variant='outlined'
                 color='primary'
                 onClick={this.continueShoppingHandler}>Continue Shopping</Button>
            </div>
            </>
        )
    }
}
export default withRouter(OrderSummary);