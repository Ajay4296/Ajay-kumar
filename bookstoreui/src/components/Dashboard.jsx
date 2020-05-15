import React, { Component } from 'react';
import Header from './Header';
import DisplayBooks from './DisplayBooks';
import Footer from './Footer';
<<<<<<< HEAD

=======
>>>>>>> 9b8b32f6efb6ee4e1af5f94cfe86cbd72052d9b7
import { getAllBooksRequestMethod, getBookCountRequestMethod } from '../services/BookServices';
import {AddCartRequestMethod} from '../services/CartServices';
import MyCart from './MyCart';
class Dashboard extends Component {

<<<<<<< HEAD

=======
>>>>>>> 9b8b32f6efb6ee4e1af5f94cfe86cbd72052d9b7
    state = {
        books: [],
        bookCount: 0,
        cartCount: 0,
<<<<<<< HEAD

=======
>>>>>>> 9b8b32f6efb6ee4e1af5f94cfe86cbd72052d9b7
        wishlistCount: 0,
        clickedId: [],
        addToBagBtnText: "Add to Bag",
        showMyCartComponent: false,

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
                    bookCount: countBookResult.data,
                })
            })    
    }

<<<<<<< HEAD
=======
    
>>>>>>> 9b8b32f6efb6ee4e1af5f94cfe86cbd72052d9b7
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

=======
>>>>>>> 9b8b32f6efb6ee4e1af5f94cfe86cbd72052d9b7
    cartIconClickedHandler = () => {
        let doesShowMyCartComponent = this.state.showMyCartComponent;
        this.setState({
            showMyCartComponent: !doesShowMyCartComponent
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
<<<<<<< HEAD

=======
>>>>>>> 9b8b32f6efb6ee4e1af5f94cfe86cbd72052d9b7
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
<<<<<<< HEAD

        let wishlistCount = this.state.wishlistCount;
        this.setState({
            wishlistCount: wishlistCount + 1

=======
        let wishlistCount = this.state.wishlistCount;
        this.setState({
            wishlistCount: wishlistCount + 1
>>>>>>> 9b8b32f6efb6ee4e1af5f94cfe86cbd72052d9b7
        })
    }

    render() {
        return (
            <>
                <Header
                    cartCount={this.state.cartCount}
<<<<<<< HEAD

=======
>>>>>>> 9b8b32f6efb6ee4e1af5f94cfe86cbd72052d9b7
                    wishlistCount={this.state.wishlistCount}
                    cartIconClickedHandler={this.cartIconClickedHandler}
                />
                {
                    this.state.showMyCartComponent ?
                        <MyCart/>
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