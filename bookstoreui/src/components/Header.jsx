import React, { Component } from 'react';
import MenuBookIcon from '@material-ui/icons/MenuBook';
import ShoppingCartIcon from '@material-ui/icons/ShoppingCart';
import FavoriteIcon from '@material-ui/icons/Favorite';
import TextField from '@material-ui/core/TextField';
import SearchIcon from '@material-ui/icons/Search';
import InputAdornment from '@material-ui/core/InputAdornment';
import Typography from '@material-ui/core/Typography';
import { Button } from '@material-ui/core';
import {getCartAddedCountRequestMethod} from '../services/CartServices';
class Header extends Component {
    
    render() {
        console.log(this.props.cartCount);
        return (
            
            <>
                <div className='header'>
                    <div className='book-logo-search-div'>
                        <div className='book-logo-div'>
                            <MenuBookIcon fontSize='large' />
                        </div>
                        <div className='book-title'>
                            <h4 className='title'>BookStore</h4>
                        </div>

                        <div className='search-div'>
                            <TextField
                                className='search-textfield'
                                InputProps={{
                                    startAdornment: (
                                        <InputAdornment position="start">
                                            <SearchIcon />
                                        </InputAdornment>
                                    ),
                                }}
                                id="outlined-basic"
                                placeholder='search'
                                variant="outlined" 
                                onChange={this.props.searchHandler}   
                                />
                        </div>
                    </div>
                    <div className='cart-wishlist-div'>
                        <div className='cart-div'>
                            <span className='icon-counter' id='lblCartCount'> {this.props.cartCount} </span>
                            <Button id='icon-btn' onClick={this.props.cartIconClickedHandler}  ><ShoppingCartIcon fontSize='large'/></Button>
                        </div>
                        <div className='wishlist-div'>
                        <span className='icon-counter' id='lblWishListCount'> {this.props.wishlistCount} </span>
                           <Button id='icon-btn' onClick={this.props.wishListIconClickedHandler}> <FavoriteIcon fontSize='large' /> </Button>
                        </div>
                    </div>
                </div>
                
            </>
        )
    }
}
export default Header;