import React, { Component } from 'react';
import { Typography, Button, RadioGroup, FormControlLabel, Radio } from '@material-ui/core';
import AddCircleOutlineIcon from '@material-ui/icons/AddCircleOutline';
import RemoveCircleOutlineIcon from '@material-ui/icons/RemoveCircleOutline';
import {
    getCartAddedCountRequestMethod, getCartValuesRequestMethod,
    deleteCartValueRequestMethod, getCustomerAddressRequestMethod, addCustomerDetailsRequestMethod
} from '../services/CartServices';
import logo from '../assets/2states.jpg';
import OrderSummary from './OrderSummary';

class MyCart extends Component {
    constructor(props) {
        super(props)
        this.state = {
            cartAddedCount: 0,
            cart: [],
            showCustomerDetails: false,
            showOrderSummary: false,
            email: "",
            name: "",
            phoneNumber: 0,
            pincode: 0,
            locality: "",
            city: "",
            address: "",
            landmark: "",
            type: "",
            showOrderSuccessful: false,
            showFilledAddress: false,
            address: [],
            orderID: 0,
            incrementDecrementCount: 1

        }
    }

    componentDidMount() {
        Promise.all([getCartAddedCountRequestMethod(), getCartValuesRequestMethod()])
            .then(([cartAddedCountResult, getCartValues]) => {
                this.setState({
                    cartAddedCount: cartAddedCountResult.data,
                    cart: getCartValues.data
                })
            })
    }

    sameBookAddHandler = (event,id) => {
       // event.preventDefault();
       // console.log(event+"+++"+id);
        let count = this.state.incrementDecrementCount;
        this.setState({
            incrementDecrementCount: count + 1
        })
    }
    sameBookRemoveHandler = (id) => {
        let count = this.state.incrementDecrementCount;
        this.setState({
            incrementDecrementCount: count - 1
        })
    }
    deleteCartHandler = async (id) => {
        const response = deleteCartValueRequestMethod({ params: { id: id } });
        await response.then(res => {
            console.log(res.data)
            const cartCountRes = getCartAddedCountRequestMethod();
            cartCountRes.then(
                res => {
                    this.setState({
                        cartAddedCount: res.data
                    })
                }
            )
            const cartValuesRes = getCartValuesRequestMethod();
            cartValuesRes.then(
                res => {
                    this.setState({
                        cart: res.data,
                    })
                }
            )
        })
    }

    placeOrderClickedHandler = () => {
        let email = window.sessionStorage.getItem('email');
        let doesShowCustomerDetails = this.state.showCustomerDetails;
        //let doesShowFilledAddress = this.state.showFilledAddress;
        let address = this.state.address;
        getCustomerAddressRequestMethod(email).then(res => {
            address.push(res.data)
            this.setState({
                showCustomerDetails: !doesShowCustomerDetails,
                showFilledAddress: true,
                address: address
            })
            console.log(this.state.address);
        })
    }

    emailHandler = (event) => {
        const email = event.target.value;
        this.setState({
            email: email,
        })
    }
    nameHandler = (event) => {
        const name = event.target.value;
        console.log("name", name);
        this.setState({
            name: name,
        })
    }
    phoneNumberHandler = (event) => {
        const phoneNumber = event.target.value;
        console.log('phoneNumber', phoneNumber)
        this.setState({
            phoneNumber: parseInt(phoneNumber)
        })
    }

    pincodeHandler = (event) => {
        const pincode = event.target.value;
        console.log("pincode", pincode);
        this.setState({
            pincode: parseInt(pincode)
        })
    }
    localityHandler = (event) => {
        const locality = event.target.value;
        console.log('locality', locality)
        this.setState({
            locality: locality
        })
    }

    cityHandler = (event) => {
        const city = event.target.value;
        console.log("city", city);
        this.setState({
            city: city,
        })
    }
    addressHandler = (event) => {
        const address = event.target.value;
        console.log('address', address)
        this.setState({
            address: address
        })
    }
    landmarkHandler = (event) => {
        const landmark = event.target.value;
        console.log("landmark", landmark);
        this.setState({
            landmark: landmark,
        })
    }
    typeHandler = (event) => {
        const type = event.target.value;
        console.log('type', type)
        this.setState({
            type: type
        })
    }
    continueCustomerDetailsHandler = async (event) => {
        event.preventDefault();
        let doesShowOrderSummary = this.state.showOrderSummary;
        let doesShowCustomerDetails = this.state.showCustomerDetails;
        this.setState({
            showOrderSummary: !doesShowOrderSummary,
            showCustomerDetails: !doesShowCustomerDetails
        })

    }
    addCustomerDetailsHandler = async (event) => {
        event.preventDefault();
        let data = {
            Email: this.state.email,
            FullName: this.state.name,
            ContactNumber: this.state.phoneNumber,
            DeliveryAddress: this.state.address,
            ZipCode: this.state.pincode,
            CityTown: this.state.city,
            LandMark: this.state.landmark,
            AddressType: this.state.type
        }
        console.log(data);
        await addCustomerDetailsRequestMethod(data).then((response) => {
            console.log(response.data, "-----------------data---------------");
        })
        let doesShowOrderSummary = this.state.showOrderSummary;
        let doesShowCustomerDetails = this.state.showCustomerDetails;
        this.setState({
            showOrderSummary: !doesShowOrderSummary,
            showCustomerDetails: !doesShowCustomerDetails
        })

    }
    checkoutClickHandler = () => {
        const doesShowOrderSuccessful = this.state.showOrderSuccessful;
        let orderID = Math.floor(Math.random() * 90000) + 10000;
        this.setState({
            showOrderSuccessful: !doesShowOrderSuccessful,
            orderID: orderID
        })
    }

    render() {
        return (
            <>
                {
                    this.state.showOrderSuccessful ?
                        <OrderSummary
                            orderID={this.state.orderID}
                        /> :
                        <div className='my-cart-main-div'>
                            <div className='my-cart-sub-div'>
                                <Typography id='mycart-title'variant="h4">My cart ({this.state.cartAddedCount})</Typography>

                                {
                                    this.state.cart.map((ele) => {
                                        return (
                                            <>
                                                <div className='book-image-details-div'>
                                                    <div className='book-image-div'>
                                                        <img id='img-cart' src={ele.bookImage} alt='error' />
                                                    </div>
                                                    <div className='book-details-div'>
                                                        <h5 className='book-h5'>{ele.bookTitle}</h5>
                                                        <Typography>{ele.authorName}</Typography>
                                                        <Typography>₹ {ele.bookPrice}</Typography>
                                                        <div className='item-quantity-div'>
                                                            <div className='increment-div'>
                                                                <Button
                                                                    onClick={() =>this.sameBookRemoveHandler(ele.cartID) }
                                                                >
                                                                    <RemoveCircleOutlineIcon />
                                                                </Button>
                                                                <span id='mycart-counter'>{this.state.incrementDecrementCount}</span>
                                                                <Button
                                                                    id={ele.cartID}
                                                                    onClick={() => this.sameBookAddHandler(ele.cartID)}
                                                                >
                                                                    <AddCircleOutlineIcon />
                                                                </Button>
                                                            </div>
                                                            <Button
                                                                variant='outlined'
                                                                color='secondary'
                                                                onClick={() => { this.deleteCartHandler(ele.cartID) }}
                                                            >Remove</Button>

                                                        </div>
                                                    </div>
                                                </div>
                                            </>
                                        )
                                    })
                                }
                                {
                                    this.state.cartAddedCount != 0 ? <div className='place-order-btn-div'>
                                        <Button
                                            variant='contained'
                                            color='primary'
                                            onClick={this.placeOrderClickedHandler}>
                                            Place order
                                        </Button>
                                    </div> : null
                                }
                            </div>
                            <div className='customer-details-div'>
                                <Typography variant="h5">Customer Details</Typography>
                                {
                                    this.state.showCustomerDetails ? this.state.showFilledAddress ?
                                        this.state.address.map(ele => {
                                            return (
                                                <form action="" className=" p-5" name="myForm" id="f" onSubmit={this.continueCustomerDetailsHandler}>
                                                    <div className="form-group">
                                                        <input type="text"
                                                            placeholder='email'
                                                            id="email"
                                                            className="form-control "
                                                            value={ele.email}

                                                        />
                                                    </div>

                                                    <div className="row">
                                                        <div className="col">
                                                            <div className="form-group">
                                                                <input type="text"
                                                                    placeholder='Name'
                                                                    id="name"
                                                                    className="form-control "
                                                                    value={ele.fullName}
                                                                />
                                                            </div>
                                                        </div>
                                                        <div className="col">
                                                            <div className="form-group">
                                                                <input type="text"
                                                                    placeholder='Phone number'
                                                                    id="phoneNumber"
                                                                    className="form-control "
                                                                    value={ele.contactNumber}
                                                                />
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div className="row">
                                                        <div className="col">
                                                            <div className="form-group">
                                                                <input type="text"
                                                                    placeholder='pincode'
                                                                    id="pincode"
                                                                    className="form-control "
                                                                    value={ele.zipCode}
                                                                />
                                                            </div>
                                                        </div>
                                                        <div className="col">
                                                            <div className="form-group">
                                                                <input type="text"
                                                                    placeholder='city/town'
                                                                    id="city/town"
                                                                    className="form-control "
                                                                    value={ele.cityTown}
                                                                />
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div className="form-group">
                                                        <input type="text"
                                                            placeholder='landmark'
                                                            id="landmark"
                                                            className="form-control "
                                                            value={ele.landMark}

                                                        />
                                                    </div>
                                                    <div className="form-group">
                                                        <input type="text"
                                                            placeholder='address'
                                                            id="address"
                                                            className="form-control "
                                                            value={ele.deliveryAddress}

                                                        />
                                                    </div>
                                                    <div className='form-group'>
                                                        <button type="submit" id="continue" className="btn btn-primary">Continue</button>
                                                    </div>
                                                </form>

                                            )
                                        })

                                        :
                                        <form action="" className=" p-5" name="myForm" id="f" onSubmit={this.addCustomerDetailsHandler}>
                                            <div className="form-group">
                                                <input type="text"
                                                    placeholder='Name' id="name"
                                                    className="form-control "
                                                    onChange={this.emailHandler} />
                                            </div>
                                            <div className="row">
                                                <div className="col">
                                                    <div className="form-group">
                                                        <input type="text" placeholder='Name' id="name" className="form-control " onChange={this.nameHandler} />
                                                    </div>
                                                </div>
                                                <div className="col">
                                                    <div className="form-group">
                                                        <input type="text" placeholder='Phone number' id="phoneNumber" className="form-control " onChange={this.phoneNumberHandler} />
                                                    </div>
                                                </div>
                                            </div>

                                            <div className="row">
                                                <div className="col">
                                                    <div className="form-group">
                                                        <input type="text" placeholder='pincode' id="pincode" className="form-control " onChange={this.pincodeHandler} />
                                                    </div>
                                                </div>
                                                <div className="col">
                                                    <div className="form-group">
                                                        <input type="text" placeholder='locality' id="locality" className="form-control " onChange={this.localityHandler} />
                                                    </div>
                                                </div>
                                            </div>

                                            <div className="row">
                                                <div className="col">
                                                    <div className="form-group">
                                                        <input type="text" placeholder='city/town' id="city" className="form-control " onChange={this.cityHandler} />
                                                    </div>
                                                </div>
                                                <div className="col">
                                                    <div className="form-group">
                                                        <input type="text" placeholder='landmark' id="landmark" className="form-control " onChange={this.landmarkHandler} />
                                                    </div>
                                                </div>
                                            </div>

                                            <div className="form-group">
                                                <input type="text" placeholder='address' id="address" className="form-control " onChange={this.addressHandler} />

                                            </div>
                                            <div className='form-group'>
                                                <label>type</label>
                                            </div>
                                            <div class="form-group form-check" id='check-box-div'>
                                                <RadioGroup row aria-label="position" name="position" defaultValue="top">
                                                    <FormControlLabel value="home" control={<Radio color="primary" />} label="Home" onChange={this.typeHandler} />
                                                    <FormControlLabel value="work" control={<Radio color="primary" />} label="Work" onChange={this.typeHandler} />
                                                    <FormControlLabel value="other" control={<Radio color="primary" />} label="Other" onChange={this.typeHandler} />
                                                </RadioGroup>
                                            </div>
                                            <div className='form-group'>
                                                <button type="submit" id="continue" className="btn btn-primary">Continue</button>
                                            </div>
                                        </form> : null
                                }
                            </div>
                            <div className='order-summary-div'>
                                <Typography variant="h5">Order summary</Typography>
                                {
                                    this.state.showOrderSummary ?
                                        this.state.cart.map((ele) => {
                                            return (
                                                <>
                                                    <div className='book-image-details-div'>
                                                        <div className='book-image-div'>
                                                            <img id='img-cart' src={ele.bookImage} alt='error' />
                                                        </div>
                                                        <div className='book-details-div'>
                                                            <Typography variant="h5" >{ele.bookTitle}</Typography>
                                                            <Typography>{ele.authorName}</Typography>
                                                            <Typography>₹ {ele.bookPrice}</Typography>
                                                        </div>
                                                    </div>
                                                </>
                                            )
                                        }) : null
                                }
                                {
                                    this.state.showOrderSummary ?
                                        <div className='place-order-btn-div'>
                                            <Button
                                                variant='contained'
                                                color='primary'
                                                onClick={this.checkoutClickHandler}
                                            >
                                                checkout
                                             </Button>
                                        </div> : null
                                }
                            </div>
                        </div>
                }
            </>
        )
    }
}
export default MyCart;