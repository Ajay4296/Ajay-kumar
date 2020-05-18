import React, { Component } from 'react';
class Pagination extends Component {
    paginate=(pageNumber) =>{
        console.log("page number", pageNumber);

        this.props.paginateNumber(pageNumber)
    }

    render() {
        const pageNumbers = [];
        for (let index = 1; index <= Math.ceil(this.props.totalPosts / this.props.postsPerPage); index++) {
            pageNumbers.push(index);
        }

        return (
            <nav className="pagination-nav" id='pagination'>
                <ul className='pagination'>
                    {
                        pageNumbers.map(number => (
                            <li key={number} className='page-item'>
                                <a onClick={() => this.paginate(number)} className='page-link'>
                                    {number}
                                </a>
                            </li>
                        ))}
                </ul>
            </nav>
        );
    }
}
export default Pagination;