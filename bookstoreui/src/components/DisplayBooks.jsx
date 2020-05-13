import React, { Component } from 'react';
import Typography from '@material-ui/core/Typography';
import Pagination from '@material-ui/lab/Pagination';
import Card from '@material-ui/core/Card';
import CardActionArea from '@material-ui/core/CardActionArea';
import CardActions from '@material-ui/core/CardActions';
import CardContent from '@material-ui/core/CardContent';
<<<<<<< HEAD
import CardMedia from '@material-ui/core/CardMedia';
import Button from '@material-ui/core/Button';
import logo from '../logo.svg';
import Tooltip from '@material-ui/core/Tooltip'; 

class DisplayBooks extends Component {
=======
import Button from '@material-ui/core/Button';
import Tooltip from '@material-ui/core/Tooltip'; 

class DisplayBooks extends Component {
    
>>>>>>> 94232d33ace64fdab9adbcf9c6338da4cd36410a
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
<<<<<<< HEAD
                                    <Card className='note-card' >
                                    <Tooltip title={ele.description}>
                                        <CardActionArea
                                            onMouseEnter={this.props.bookMouseEnterHandler}
                                            onMouseLeave={this.props.bookMouseLeaveHandler}
                                        >
                                            <img id='img' src={logo} />
                                            {/* <CardMedia
=======
                                    <Card className='note-card' key={ele.bookID}>
                                        
                                        <Tooltip  title={ele.summary}> 
                                        <CardActionArea> 
                                            <img id='img' src={ele.bookImage} />
                                            
                                            {
                                                /* <CardMedia
                                            
>>>>>>> 94232d33ace64fdab9adbcf9c6338da4cd36410a
                                image={logo}
                            /> */}
                                            <CardContent id='card-content'>
                                                <Typography gutterBottom variant="h5" component="h2">
<<<<<<< HEAD
                                                    {ele.bookName}
=======
                                                     {ele.bookTittle}
>>>>>>> 94232d33ace64fdab9adbcf9c6338da4cd36410a
                                                </Typography>
                                                <Typography id='note-content' variant="body2" color="textSecondary" component="p">
                                                    by: {ele.authorName}
                                                </Typography>
                                                <Typography id='note-content' variant="body2" color="textSecondary" component="p">
<<<<<<< HEAD
                                                ₹ {ele.price}
=======
                                                    ₹ {ele.price}
>>>>>>> 94232d33ace64fdab9adbcf9c6338da4cd36410a
                                                </Typography>
                                            </CardContent>
                                        </CardActionArea>
                                        </Tooltip>
                                        <CardActions>
<<<<<<< HEAD
                                            <Button
                                                variant='outlined'
                                                color='primary'
                                                onClick={this.props.addToBagClickHandler}
                                            > Add to Bag</Button>

                                            <Button
                                                variant='outlined'
                                                color='secondary'
                                                onClick={this.props.addToWishlistClickHandler}
                                            > WishList</Button>

                                        </CardActions>
                                    </Card>
                                 
=======

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
>>>>>>> 94232d33ace64fdab9adbcf9c6338da4cd36410a
                                </>
                            );
                        })
                    }
<<<<<<< HEAD

                </div>
                {/* <div className='pagination-div'>
                    <Pagination count={10} 
                    color="primary" />
=======
                </div>
                {/* <div className='pagination-div'>
                    <Pagination 
                    count={Math.floor(this.props.bookCount/12)} 
                    color="primary" 
                    onClick={this.props.onChangePaginationHandler} />
>>>>>>> 94232d33ace64fdab9adbcf9c6338da4cd36410a
                </div> */}
            </>
        )

    }
}
export default DisplayBooks;