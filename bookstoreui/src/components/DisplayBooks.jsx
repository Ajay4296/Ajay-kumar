import React, { Component } from 'react';
import Typography from '@material-ui/core/Typography';
import Pagination from '@material-ui/lab/Pagination';
import Card from '@material-ui/core/Card';
import CardActionArea from '@material-ui/core/CardActionArea';
import CardActions from '@material-ui/core/CardActions';
import CardContent from '@material-ui/core/CardContent';
import CardMedia from '@material-ui/core/CardMedia';
import Button from '@material-ui/core/Button';
import logo from '../logo.svg';

class DisplayBooks extends Component {
    render() {
        return (
            <>
                <div className='bookcount-sortby-div'>
                    <Typography variant='h5'>
                        Books(128 items)
                        </Typography>
                    <div>
                        <select name="Sort By Relevance" id="Sort_By_Relevance" className='form-control text-dark font-weight-bold' >
                            <option value="-1" selected>Sort By Relevance</option>
                            <option name="price:low to high">price:low to high</option>
                            <option name="price:high to low">price:high to low</option>
                            <option name="Newest Arrivals">Newest Arrivals</option>
                        </select>
                    </div>
                </div>
                <div className='display-books-div'>
                    {
                        this.props.sliceData.map((ele) => {
                            return (
                                <>
                                    <Card className='note-card' >
                                        <CardActionArea
                                            onMouseEnter={this.props.bookMouseEnterHandler}
                                            onMouseLeave={this.props.bookMouseLeaveHandler}
                                        >
                                            <img src={logo} />
                                            {/* <CardMedia
                                image={logo}
                            /> */}
                                            <CardContent id='card-content'>
                                                <Typography gutterBottom variant="h5" component="h2">
                                                    {ele.bookName}
                                                </Typography>
                                                <Typography id='note-content' variant="body2" color="textSecondary" component="p">
                                                    {ele.authorName}
                                                </Typography>
                                                <Typography id='note-content' variant="body2" color="textSecondary" component="p">
                                                    {ele.price}
                                                </Typography>
                                            </CardContent>
                                        </CardActionArea>
                                        <CardActions>
                                            <Button
                                                variant='outlined'
                                                color='primary'
                                            > Add to Bag</Button>

                                            <Button
                                                variant='outlined'
                                                color='secondary'
                                            > WishList</Button>

                                        </CardActions>
                                    </Card>
                                 
                                </>
                            );
                        })
                    }

                </div>
                <div className='pagination-div'>
                    <Pagination count={10} 
                    color="primary" />
                </div>
            </>
        )

    }
}
export default DisplayBooks;