import React, { Component } from 'react';
import { Typography } from '@material-ui/core';

class Wishlist extends Component {
    render() {
        return (
            <>
                <div className='my-cart-main-div'>
                    <div className='order-summary-div'>
                        <Typography variant="h5">Wishlist</Typography>


                        {
                            this.props.wishlist.map((ele) => {
                                return (
                                    <div className='book-image-details-div'>
                                        <div className='book-image-div'>
                                            <img id='img-cart' src={ele.bookImage} alt='error' />
                                        </div>
                                        <div className='book-details-div'>
                                            <Typography variant="h5" >{ele.bookTittle}</Typography>
                                            <Typography>{ele.authorName}</Typography>
                                            <Typography>₹ {ele.price}</Typography>
                                        </div>
                                    </div>
                                )
                            })

                        }
                    </div>

                </div>

            </>
        )
    }
}
export default Wishlist