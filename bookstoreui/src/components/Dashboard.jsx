import React, { Component } from 'react';
import Header from './Header';
import DisplayBooks from './DisplayBooks';
import Footer from './Footer';
class Dashboard extends Component {
    state = {
        books: [
            {
                bookid: 1,
                bookName: "shreyash's biography",
                authorName: "shreyash kaushal",
                price: 1235,
                description: "bfjhgsbmhgszbxkvbgmbfdkjbvmbfmvbdxbcmf",
                image: ""
            },
            {
                bookid: 2,
                bookName: "Saad's biography",
                authorName: "Saad Samim",
                price: 12356,
                description: "bfjhgsbmhgszbxkvbgmbfdkjbvmbfmvbdxbcmf",
                image: ""

            },
             {
                bookid: 3,
                bookName: "Shraddha's world",
                authorName: "Shraddha Singh",
                price: 12356,
                description: "bfjhgsbmhgszbxkvbgmbfdkjbvmbfmvbdxbcmf",
                image: ""

            }, {
                bookid: 4,
                bookName: "World of PUBG",
                authorName: "Jayant Pareek",
                price: 12356,
                description: "bfjhgsbmhgszbxkvbgmbfdkjbvmbfmvbdxbcmf",
                image: ""

            }, {
                bookid: 5,
                bookName: "Chess Life",
                authorName: "Shivam Dewangan",
                price: 12356,
                description: "bfjhgsbmhgszbxkvbgmbfdkjbvmbfmvbdxbcmf",
                image: ""

            }, {
                bookid: 6,
                bookName: "Food is life",
                authorName: "Mayank Singh",
                price: 12356,
                description: "bfjhgsbmhgszbxkvbgmbfdkjbvmbfmvbdxbcmf",
                image: ""

            }],
            bookCount: 17,
            cartCount : 0 ,
            wishListCount : 0
            // pageNo: 0,
            // offset: 0,
            // perPage: 12,
            // sliceData: []
    }
   
//     componentDidMount()
// {
//     this.changePageHandler();
// }
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

addToBagClickHandler=()=>{
    let cartCount = this.state.cartCount;
    this.setState({
      cartCount : cartCount + 1  
    })
}

addToWishlistClickHandler=()=>{
    let wishListCount = this.state.wishListCount;
    this.setState({
      wishListCount : wishListCount + 1  
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
                bookCount = {this.state.bookCount}
                addToBagClickHandler={this.addToBagClickHandler}
                addToWishlistClickHandler={this.addToWishlistClickHandler}
                />
                <Footer/>
            </>
        )

    }
}
export default Dashboard;