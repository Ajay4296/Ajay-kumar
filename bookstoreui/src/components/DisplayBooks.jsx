import React, { Component } from 'react';
import Typography from '@material-ui/core/Typography';
import Pagination from '@material-ui/lab/Pagination';
import Card from '@material-ui/core/Card';
import CardActionArea from '@material-ui/core/CardActionArea';
import CardActions from '@material-ui/core/CardActions';
import CardContent from '@material-ui/core/CardContent';
import Button from '@material-ui/core/Button';
import Tooltip from '@material-ui/core/Tooltip'; 

class DisplayBooks extends Component {
    render() {
        return (
            <>
                <div className='bookcount-sortby-div'>
                    <Typography variant='h5'>
                        Books<span id='bookcountfont'>({this.props.bookCount} items)</span>
                        </Typography>
                    <div>
                        <select name="Sort By Relevance" id="Sort_By_Relevance" >
                            <option value="-1" selected>Sort By Relevance</option>
                            <option name="price:low to high">price:low to high</option>
                            <option name="price:high to low">price:high to low</option>
                            <option name="Newest Arrivals">Newest Arrivals</option>
                        </select>
                    </div>
                </div>
                <div className='display-books-div'>
                    {
                        this.props.books.map((ele) => {
                            return (
                                <>
                                    <Card className='note-card' key={ele.bookID}>
                                        
                                        <Tooltip  title={ele.summary}> 
                                        <CardActionArea> 
                                            <img id='img' src={ele.bookImage} />
                                            
                                            {
                                                /* <CardMedia
                                            

                                image={logo}
                            /> */}
                                            <CardContent id='card-content'>
                                                <Typography gutterBottom variant="h5" component="h2">

                                                     {ele.bookTittle}

                                                </Typography>
                                                <Typography id='note-content' variant="body2" color="textSecondary" component="p">
                                                    by: {ele.authorName}
                                                </Typography>
                                                <Typography id='note-content' variant="body2" color="textSecondary" component="p">

                                                    ₹ {ele.price}

                                                </Typography>
                                            </CardContent>
                                        </CardActionArea>
                                        </Tooltip>
                                        <CardActions>

                                        {
                                            this.props.clickedId.includes(ele.bookID) ?
                                            <Button
                                                variant='outlined'
                                                color='primary'
                                                onClick={()=>{this.props.addToBagClickHandler(ele.bookID)}}
                                            > Added to bag</Button> :
                                            <>
                                            <Button
                                                variant='outlined'
                                                color='primary'
                                                onClick={()=>{this.props.addToBagClickHandler(ele.bookID)}}
                                            > Add to bag</Button>
                                            <Button
                                                variant='outlined'
                                                color='secondary'
                                                onClick = {this.props.addToWishlistClickHandler}
                                            > WishList</Button>
                                            </>
                                        }
                                        </CardActions>
                                    </Card>

                                </>
                            );
                        })
                    }

                </div>
                {/* <div className='pagination-div'>
                    <Pagination 
                    count={Math.floor(this.props.bookCount/12)} 
                    color="primary" 
                    onClick={this.props.onChangePaginationHandler} />

                </div> */}
            </>
        )

    }
}
export default DisplayBooks;