import React, { Component } from 'react';
import Header from './Header';
import DisplayBooks from './DisplayBooks';
import Footer from './Footer';
import { getAllBooksRequestMethod, getBookCountRequestMethod } from '../services/BookServices';
import {AddCartRequestMethod,getCartAddedCountRequestMethod,getCartValuesRequestMethod,deleteCartValueRequestMethod} from '../services/CartServices';
import MyCart from './MyCart';
class Dashboard extends Component {

    state = {
        books: [],
        bookCount: 0,
        cartCount: 0,
        wishlistCount: 0,
        clickedId: [],
        addToBagBtnText: "Add to Bag",
        showMyCartComponent: false,
        showCustomerDetails: false,
        cartAddedCount : 0,
        cart:[]

        // pageNo: 0,
        // offset: 0,
        // perPage: 12,
        // sliceData: [],

    }

    // bookMouseEnterHandler=(id)=>{
    //   console.log(id);
    //   let books = this.state.books;
    //   let resultantBook = books.filter((ele)=>{
    //       return ele.id === id;
    //   })
    //   console.log(resultantBook);  
    //   const doesBookHoverState = this.state.bookHoverState;
    //   this.setState({
    //     bookHoverState:!doesBookHoverState,
    //     bookDescription : resultantBook.description
    //   })
    // }

    // bookMouseLeaveHandler=()=>{
    //     const doesBookHoverState = this.state.bookHoverState;
    //     this.setState({
    //       bookHoverState:!doesBookHoverState
    //     })
    //   }
    componentDidMount() {
        Promise.all([getAllBooksRequestMethod(), getBookCountRequestMethod(),getCartAddedCountRequestMethod(),getCartValuesRequestMethod()])
            .then(([getallBookResult, countBookResult,cartAddedCountResult,getCartValues]) => {
                this.setState({
                    books: getallBookResult.data,
                    bookCount: countBookResult.data,
                    cartAddedCount: cartAddedCountResult.data,
                    cart : getCartValues.data
                })
            })    
    }

    deleteCartHandler = async(id)=>{
     const response = deleteCartValueRequestMethod({ params: { id: id } });
      await response.then(res=>{
            console.log(res.data);
        })
    }
    //     onChangePaginationHandler =  (event,value) => {
    //         event.preventDefault();
    //         let pageNumber = value;
    //         let offset = pageNumber * this.state.perPage;
    //         console.log(pageNumber);
    //         this.setState({
    //             offset: offset
    //         })
    //      this.changePageHandler();
    //     }

    //     changePageHandler =  () => {
    //         let books = this.state.books;
    //         let sliceData = books.slice(this.state.offset, this.state.offset + this.state.perPage);
    //         this.setState({
    //             sliceData: sliceData
    //         })

    //     }

    cartIconClickedHandler = () => {
        let doesShowMyCartComponent = this.state.showMyCartComponent;
        this.setState({
            showMyCartComponent: !doesShowMyCartComponent
        })
    }

    placeOrderClickedHandler=()=>{
        let doesShowCustomerDetails = this.state.showCustomerDetails;
        this.setState({
            showCustomerDetails : !doesShowCustomerDetails
        })
    }

    addToBagClickHandler = (clickedID,bookAvailable) => {
        let cartCount = this.state.cartCount;
        let clickedidArray = this.state.clickedId;
        clickedidArray.push(clickedID);
        console.log(clickedID);
        this.setState({
            cartCount: cartCount + 1,
            clickedId: [...clickedidArray],
            addToBagBtnText: "Added to bag"
        })
        var cart = {
            Book_ID: clickedID ,
            SelectBookCount: bookAvailable
        }
       const response = AddCartRequestMethod(cart);
       response.then(res=>{
          console.log(res.data); 
       })
    }

    addToWishlistClickHandler = () => {
        let wishlistCount = this.state.wishlistCount;
        this.setState({
            wishlistCount: wishlistCount + 1
        })
    }

    render() {
        return (
            <>
                <Header
                    cartCount={this.state.cartCount}
                    wishlistCount={this.state.wishlistCount}
                    cartIconClickedHandler={this.cartIconClickedHandler}
                />
                {
                    this.state.showMyCartComponent ?
                        <MyCart
                            placeOrderClickedHandler={this.placeOrderClickedHandler}
                            showCustomerDetails = {this.state.showCustomerDetails}
                            cartAddedCount = {this.state.cartAddedCount}
                            cart = {this.state.cart}
                            deleteCartHandler={this.deleteCartHandler}
                        />
                        :
                        <DisplayBooks
                            books={this.state.books}
                            bookCount={this.state.bookCount}
                            onChangePaginationHandler={this.onChangePaginationHandler}
                            addToBagClickHandler={this.addToBagClickHandler}
                            addToWishlistClickHandler={this.addToWishlistClickHandler}
                            clickedId={this.state.clickedId}
                            addToBagBtnText={this.state.addToBagBtnText}
                        />
                }

                <Footer />
            </>
        )

    }
}
export default Dashboard;