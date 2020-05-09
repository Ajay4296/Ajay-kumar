import React, { Component } from 'react';
import MenuBookIcon from '@material-ui/icons/MenuBook';
import ShoppingCartIcon from '@material-ui/icons/ShoppingCart';
import FavoriteIcon from '@material-ui/icons/Favorite';
import TextField from '@material-ui/core/TextField';
import SearchIcon from '@material-ui/icons/Search';
import InputAdornment from '@material-ui/core/InputAdornment';
import Typography from '@material-ui/core/Typography';
class Header extends Component {
    render() {
        return (
            <>
                <div className='header'>
                    <div className='book-logo-search-div'>
                        <div className='book-logo-div'>
                            <MenuBookIcon fontSize='large' />
                        </div>
                        <div className='book-title'>
                            <Typography variant='h4'>
                                Book Store
                        </Typography>
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
                                variant="outlined" />
                        </div>
                    </div>
                    <div className='cart-wishlist-div'>
                        <div className='cart-div'>
                            <span className='icon-counter' id='lblCartCount'> {this.props.cartCount} </span>
                            <ShoppingCartIcon fontSize='large' />
                        </div>
                        <div className='wishlist-div'>
                            <span className='icon-counter' id='lblWishCount'> {this.props.wishListCount} </span>
                            <FavoriteIcon fontSize='large' />
                        </div>
                    </div>
                </div>
                                
            </>
        )

    }
}
export default Header;