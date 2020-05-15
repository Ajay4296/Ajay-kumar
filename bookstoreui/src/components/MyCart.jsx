import React, { Component } from 'react';
import { Typography, Button } from '@material-ui/core';
import AddCircleOutlineIcon from '@material-ui/icons/AddCircleOutline';
import RemoveCircleOutlineIcon from '@material-ui/icons/RemoveCircleOutline';
import {getCartAddedCountRequestMethod,getCartValuesRequestMethod,deleteCartValueRequestMethod} from '../services/CartServices';
import logo from '../assets/2states.jpg';

class MyCart extends Component {
    state={
        cartAddedCount:0,
        cart : [],
        showCustomerDetails: false,

    }
    componentDidMount(){
        Promise.all([getCartAddedCountRequestMethod(),getCartValuesRequestMethod()])
        .then(([cartAddedCountResult,getCartValues]) => {
            this.setState({
                cartAddedCount: cartAddedCountResult.data,
                cart : getCartValues.data
            })
        })
    }

    deleteCartHandler = async(id)=>{
        const response = deleteCartValueRequestMethod({ params: { id: id } });
         await response.then(res=>{
           console.log(res.data)
          const cartCountRes= getCartAddedCountRequestMethod();
          cartCountRes.then(
              res=>{
                  this.setState({
                      cartAddedCount : res.data
                  })
              }
          )
          const cartValuesRes= getCartValuesRequestMethod();
               cartValuesRes.then(
                   res=>{
                       this.setState({
                           cart : res.data
                       })
                   }
               )
           })
       }

       placeOrderClickedHandler=()=>{
        let doesShowCustomerDetails = this.state.showCustomerDetails;
        this.setState({
            showCustomerDetails : !doesShowCustomerDetails
        })
    }
    render() {
        return (
            <div className='my-cart-main-div'>
                <div className='my-cart-sub-div'>
                    <Typography variant="h4">My cart ({this.state.cartAddedCount})</Typography>
                    
                    {
                        this.state.cart.map((ele)=>{
                            return(
                                <>
                                <div className='book-image-details-div'>
                                <div className='book-image-div'>
                            <img id='img-cart' src={ele.bookImage} alt='error' />
                        </div>
                        <div className='book-details-div'>
                            <Typography variant="h5" >{ele.bookTitle}</Typography>
                            <Typography>{ele.authorName}</Typography>
                            <Typography>₹ {ele.bookPrice}</Typography>
                            <div className='item-quantity-div'>
                                <Button>
                                    <RemoveCircleOutlineIcon />
                                </Button>
                                <span id='mycart-counter'>1</span>
                                <Button>
                                    <AddCircleOutlineIcon />
                                </Button>

                                <Button
                                    variant='outlined'
                                    color='secondary'
                                    onClick={()=>{this.deleteCartHandler(ele.cartID)}}
                                >Remove</Button>

                            </div>
                        </div>
                    </div>
                    </>
                            )
                        })
                    }
                       
                    <div className='place-order-btn-div'>
                        <Button 
                        variant='contained' 
                        color='primary' 
                        onClick={this.placeOrderClickedHandler}>
                            Place order
                    </Button>
                    </div>
                </div>
                <div className='customer-details-div'>
                    <Typography variant="h5">Customer Details</Typography>
                    {
                        this.state.showCustomerDetails ?
                        <form action="" className=" p-5" name="myForm" id="f" >
                        <div className="row">
                            <div className="col">
                                <div className="form-group">
                                    <input type="text" placeholder='Name' id="name" className="form-control " />
                                </div>
                            </div>
                            <div className="col">
                                <div className="form-group">
                                    <input type="text" placeholder='Phone number' id="phoneNumber" className="form-control " onChange={this.lastNameHandler} />
                                </div>
                            </div>
                        </div>

                        <div className="row">
                            <div className="col">
                                <div className="form-group">
                                    <input type="text" placeholder='pincode' id="pincode" className="form-control " />
                                </div>
                            </div>
                            <div className="col">
                                <div className="form-group">
                                    <input type="text" placeholder='locality' id="locality" className="form-control " onChange={this.lastNameHandler} />
                                </div>
                            </div>
                        </div>

                        <div className="row">
                            <div className="col">
                                <div className="form-group">
                                    <input type="text" placeholder='city/town' id="city" className="form-control " />
                                </div>
                            </div>
                            <div className="col">
                                <div className="form-group">
                                    <input type="text" placeholder='landmark' id="landmark" className="form-control " onChange={this.lastNameHandler} />
                                </div>
                            </div>
                        </div>

                        <div className="form-group">
                            <input type="text" placeholder='address' id="address" className="form-control " onChange={this.passwordHandler} />

                        </div>
                        <div className='form-group'>
                            <label>type</label>
                        </div>
                        <div class="form-group form-check" id='check-box-div'>
                            <label class="form-check-label" id='form-check-label'>
                                <input class="form-check-input" type="checkbox" /> Home
                            </label>
                            <label class="form-check-label" id='form-check-label'>
                                <input class="form-check-input" type="checkbox" /> Work
                            </label>
                            <label class="form-check-label" id='form-check-label'>
                                <input class="form-check-input" type="checkbox" /> other
                            </label>
                        </div>
                        <div className='form-group'>
                            <button type="submit" id="continue" className="btn btn-primary">Continue</button>
                        </div>
                    </form> : null 
                    }
                </div>
                <div className='order-summary-div'>
                    <Typography variant="h5">Order summary</Typography>
                </div>
            </div>
        )
    }
}
export default MyCart;