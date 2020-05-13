import React, { Component } from 'react';
import Header from './Header';
import DisplayBooks from './DisplayBooks';
import Footer from './Footer';
<<<<<<< HEAD
import {getAllBooksRequestMethod,getBookCountRequestMethod} from '../services/BookService';

class Dashboard extends Component {
=======
import { getAllBooksRequestMethod, getBookCountRequestMethod } from '../services/BookServices';
import MyCart from './MyCart';
class Dashboard extends Component {

>>>>>>> 94232d33ace64fdab9adbcf9c6338da4cd36410a
    state = {
        books: [],
        bookCount: 0,
        cartCount: 0,
<<<<<<< HEAD
        wishListCount: 0
        // pageNo: 0,
        // offset: 0,
        // perPage: 12,
        // sliceData: []
    }

    componentDidMount()
{
    Promise.all([getAllBooksRequestMethod(),getBookCountRequestMethod()])
    .then(([getallBookResult,countBookResult])=>{
        this.setState({
            books:getallBookResult.data,
            bookCount : countBookResult.data
        })
    })
}

    
=======
        wishlistCount: 0,
        clickedId: [],
        addToBagBtnText: "Add to Bag",
        showMyCartComponent: false,
        showCustomerDetails: false

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
        Promise.all([getAllBooksRequestMethod(), getBookCountRequestMethod()])
            .then(([getallBookResult, countBookResult]) => {
                this.setState({
                    books: getallBookResult.data,
                    bookCount: countBookResult.data
                })
            })    
    }
>>>>>>> 94232d33ace64fdab9adbcf9c6338da4cd36410a
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

<<<<<<< HEAD
    addToBagClickHandler = () => {
        let cartCount = this.state.cartCount;
        this.setState({
            cartCount: cartCount + 1
=======
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

    addToBagClickHandler = (clickedID) => {
        let cartCount = this.state.cartCount;
        let clickedidArray = this.state.clickedId;
        clickedidArray.push(clickedID);
        console.log(clickedID);
        this.setState({
            cartCount: cartCount + 1,
            clickedId: [...clickedidArray],
            addToBagBtnText: "Added to bag"
>>>>>>> 94232d33ace64fdab9adbcf9c6338da4cd36410a
        })
    }

    addToWishlistClickHandler = () => {
<<<<<<< HEAD
        let wishListCount = this.state.wishListCount;
        this.setState({
            wishListCount: wishListCount + 1
=======
        let wishlistCount = this.state.wishlistCount;
        this.setState({
            wishlistCount: wishlistCount + 1
>>>>>>> 94232d33ace64fdab9adbcf9c6338da4cd36410a
        })
    }

    render() {
        return (
            <>
                <Header
                    cartCount={this.state.cartCount}
<<<<<<< HEAD
                    wishListCount={this.state.wishListCount}
                />
                <DisplayBooks
                    books={this.state.books}
                    bookCount={this.state.bookCount}
                    addToBagClickHandler={this.addToBagClickHandler}
                    addToWishlistClickHandler={this.addToWishlistClickHandler}
                />
=======
                    wishlistCount={this.state.wishlistCount}
                    cartIconClickedHandler={this.cartIconClickedHandler}
                />
                {
                    this.state.showMyCartComponent ?
                        <MyCart
                            placeOrderClickedHandler={this.placeOrderClickedHandler}
                            showCustomerDetails = {this.state.showCustomerDetails}
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

>>>>>>> 94232d33ace64fdab9adbcf9c6338da4cd36410a
                <Footer />
            </>
        )

    }
}
export default Dashboard;