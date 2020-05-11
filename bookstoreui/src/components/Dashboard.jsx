import React, { Component } from 'react';
import Header from './Header';
import DisplayBooks from './DisplayBooks';
import Footer from './Footer';
import {getAllBooksRequestMethod,getBookCountRequestMethod} from '../services/BookServices';

class Dashboard extends Component {
    state = {
        books: [],
        bookCount: 0,
        cartCount: 0,
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

    addToBagClickHandler = () => {
        let cartCount = this.state.cartCount;
        this.setState({
            cartCount: cartCount + 1
        })
    }

    addToWishlistClickHandler = () => {
        let wishListCount = this.state.wishListCount;
        this.setState({
            wishListCount: wishListCount + 1
        })
    }

    render() {
        return (
            <>
                <Header
                    cartCount={this.state.cartCount}
                    wishListCount={this.state.wishListCount}
                />
                <DisplayBooks
                    books={this.state.books}
                    bookCount={this.state.bookCount}
                    addToBagClickHandler={this.addToBagClickHandler}
                    addToWishlistClickHandler={this.addToWishlistClickHandler}
                />
                <Footer />
            </>
        )

    }
}
export default Dashboard;