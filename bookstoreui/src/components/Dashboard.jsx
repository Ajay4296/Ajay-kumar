import React, { Component } from 'react';
import Header from './Header';
import DisplayBooks from './DisplayBooks';
import Footer from './Footer';
import { getAllBooksRequestMethod, getBookCountRequestMethod } from '../services/BookServices';
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

    addToBagClickHandler = (clickedID) => {
        let cartCount = this.state.cartCount;
        let clickedidArray = this.state.clickedId;
        clickedidArray.push(clickedID);
        console.log(clickedID);
        this.setState({
            cartCount: cartCount + 1,
            clickedId: [...clickedidArray],
            addToBagBtnText: "Added to bag"

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