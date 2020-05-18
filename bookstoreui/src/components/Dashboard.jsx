import React, { Component } from 'react';
import Header from './Header';
import DisplayBooks from './DisplayBooks';
import Footer from './Footer';
import { getAllBooksRequestMethod, getBookCountRequestMethod } from '../services/BookServices';
import { AddCartRequestMethod, getCartAddedCountRequestMethod } from '../services/CartServices';
import MyCart from './MyCart';
import Pagination from './Pagination';
import {withRouter } from 'react-router-dom';
import Wishlist from './Wishlist';

class Dashboard extends Component {

    state = {
        books: [],
        bookCount: 0,
        cartCount: 0,
        wishlistCount: 0,
        clickedId: [],
        addToBagBtnText: "Add to Bag",
        showMyCartComponent: false,
        filterArray: [],
        isSearching: false,
        filterArrayCount: 0,
        currentPage: 1,
        postsPerPage: 12,
        wishlist:[],
        ShowWishListComponent:false
    }

    componentDidMount() {
        Promise.all([getAllBooksRequestMethod(), getBookCountRequestMethod(), getCartAddedCountRequestMethod()])
            .then(([getallBookResult, countBookResult,cartCountResult]) => {
                this.setState({
                    books: getallBookResult.data,
                       bookCount: countBookResult.data,
                    cartCount : cartCountResult.data
                })
            })
    }

    paginate = (pageNumber) => {
        this.setState({
            currentPage: pageNumber
        })
        console.log("pagenumber after", this.state.currentPage);
    }


    cartIconClickedHandler = () => {
        let doesShowMyCartComponent = this.state.showMyCartComponent;
        this.setState({
            showMyCartComponent: !doesShowMyCartComponent
        })
    }

    wishListIconClickedHandler = () => {
        let doesShowWishListComponent = this.state.ShowWishListComponent;
        this.setState({
            ShowWishListComponent: !doesShowWishListComponent
        })
    }

    searchHandler = (event) => {
        let search = event.target.value;
        if (search.toString().length >= 1) {
            const newData = this.state.books.filter(item => {
                return (
                    item.bookTittle.toLowerCase().indexOf(search.toLowerCase()) > -1 ||
                    item.authorName.toLowerCase().indexOf(search.toLowerCase()) > -1
                );
            })
            this.setState({
                isSearching: true,
                filterArray: newData,
                filterArrayCount: newData.length
            })
        }
        else {
            this.setState({
                isSearching: false
            })
        }
    }

    sortByRelevanceHandler=(event)=>{
      const selection = event.target.value; 
      let books = this.state.books
      console.log(selection);
      if(selection.toString() === "price: low to high")
      {
        function compare(a, b) {
            let comparison = 0;
            if (a.price < b.price) {
              comparison = -1;
            } 
            return comparison;
          }
          this.setState({
            books:books.sort(compare)
            })
      }
      else{
        function compare(a, b) {
            let comparison = 0;
            if (a.price > b.price) {
              comparison = -1;
            }
            return comparison;
          }
          this.setState({
            books:books.sort(compare)
            })

      }
      
      
    }

    addToBagClickHandler = (clickedID, bookAvailable) => {
        let cartCount = this.state.cartCount;
        let clickedidArray = this.state.clickedId;
        clickedidArray.push(clickedID);
        console.log(clickedID);
        //console.log(window.sessionStorage.getItem("email"));
        this.setState({
            cartCount: cartCount + 1,
            clickedId: [...clickedidArray],
            addToBagBtnText: "Added to bag"
        })
        var cart = {
            Book_ID: clickedID,
            SelectBookCount: bookAvailable
        }
        const response = AddCartRequestMethod(cart);
        response.then(res => {
            console.log(res.data);
        })
    }

    addToWishlistClickHandler = async (clickedID) => {
        let wishlistCount = this.state.wishlistCount;
        let result = this.state.books.filter(ele=>{
            return ele.bookID == clickedID
        })
      await  this.setState({
            wishlistCount: wishlistCount + 1,
            wishlist : [...result]
        })
        console.log(this.state.wishlist)
    }

    render() {

        const indexOfLastPost = this.state.currentPage * this.state.postsPerPage;
        const indexOfFirstPost = indexOfLastPost - this.state.postsPerPage;
        const currentPosts = this.state.books.slice(indexOfFirstPost, indexOfLastPost);
        return (
            <>
                <Header
                    cartCount={this.state.cartCount}
                    wishlistCount={this.state.wishlistCount}
                    cartIconClickedHandler={this.cartIconClickedHandler}
                    searchHandler={this.searchHandler}
                    wishListIconClickedHandler={this.wishListIconClickedHandler}
                />
                {
                    this.state.showMyCartComponent ?<MyCart />
                        : this.state.ShowWishListComponent ? 
                        <Wishlist
                            wishlist={this.state.wishlist}
                        /> :
                        <>
                            <DisplayBooks
                                books={this.state.isSearching ? this.state.filterArray :currentPosts}
                                bookCount={this.state.isSearching ? this.state.filterArrayCount : this.state.bookCount}
                                onChangePaginationHandler={this.onChangePaginationHandler}
                                addToBagClickHandler={this.addToBagClickHandler}
                                addToWishlistClickHandler={this.addToWishlistClickHandler}
                                clickedId={this.state.clickedId}
                                addToBagBtnText={this.state.addToBagBtnText}
                                sortByRelevanceHandler={this.sortByRelevanceHandler}
                            />
                            <Pagination postsPerPage={this.state.postsPerPage}
                                totalPosts={this.state.books.length}
                                paginateNumber={this.paginate} />
                        </>
                }

                <Footer />
            </>
        )

    }
}
export default withRouter(Dashboard);