import React, { Component } from 'react';
import Header from './Header';
import DisplayBooks from './DisplayBooks';
import Footer from './Footer';
class Dashboard extends Component {
    state = {
        books: [
            {
                bookid: 212323,
                bookName: "shreyash's biography",
                authorName: "shreyash kaushal",
                price: 1235,
                description: "bfjhgsbmhgszbxkvbgmbfdkjbvmbfmvbdxbcmf",
                image: ""
            },
            {
                bookid: 212323,
                bookName: "Saad's    biography",
                authorName: "Saad Samim",
                price: 12356,
                description: "bfjhgsbmhgszbxkvbgmbfdkjbvmbfmvbdxbcmf",
                image: ""

            }, {
                bookid: 212323,
                bookName: "Shradha's world",
                authorName: "Shraddha Singh",
                price: 12356,
                description: "bfjhgsbmhgszbxkvbgmbfdkjbvmbfmvbdxbcmf",
                image: ""

            }, {
                bookid: 212323,
                bookName: "World of PUBG",
                authorName: "Jayant Pareek",
                price: 12356,
                description: "bfjhgsbmhgszbxkvbgmbfdkjbvmbfmvbdxbcmf",
                image: ""

            }, {
                bookid: 212323,
                bookName: "Chess Life",
                authorName: "Shivam Dewangan",
                price: 12356,
                description: "bfjhgsbmhgszbxkvbgmbfdkjbvmbfmvbdxbcmf",
                image: ""

            }, {
                bookid: 212323,
                bookName: "Food is life",
                authorName: "Mayank Singh",
                price: 12356,
                description: "bfjhgsbmhgszbxkvbgmbfdkjbvmbfmvbdxbcmf",
                image: ""

            }],
            bookCount: 128,
            pageNo: 0,
            offset: 0,
            perPage: 12,
            sliceData: []
    }
   
    

    render() {
        return (
            <>
                <Header />
                <DisplayBooks books={this.state.books}
                    bookMouseEnterHandler={this.bookMouseEnterHandler}
                    bookMouseLeaveHandler={this.bookMouseLeaveHandler}
                    bookHoverState={this.state.bookHoverState}
                />
                <Footer/>
            </>
        )

    }
}
export default Dashboard;