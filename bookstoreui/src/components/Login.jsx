import React, { Component } from 'react';
<<<<<<< HEAD
import { loginEmployeeRequestHandler } from '../../Services/LoginServices';
class Login extends Component {
  constructor(props) {
    super(props)
    this.state = {
      email: "",
      password: "",
      loginAuthentication: false,
      showError:false
    }
  }

  emailHandler = (event) => {
    const email = event.target.value;
    console.log("email", email);
    this.setState({
      email: email,
    })
  }
  passwordHandler = (event) => {
    const password = event.target.value;
    console.log('password', password)
    this.setState({
      password: password
    })
  }

  submitHandler = (event) => {
    event.preventDefault();
    var data = {
      email: this.state.email,
      password: this.state.password
    }
    const response = loginEmployeeRequestHandler(data);
      response.then(res => {
        console.log(res);
        if (res.data === data.email) {
          this.setState({
            loginAuthentication: true
          })
        }
        this.props.history.push('/Dashboard');
      }).catch(()=>{
        //alert("email or password is incorrect");
        this.setState({
          showError:true
        })
      })
  }
=======
class Login extends Component {
  // constructor(props) {
  //   super(props)
  //   this.state = {
  //     email: "",
  //     password: "",
  //     loginAuthentication: false,
  //     showError:false
  //   }
  // }

  // emailHandler = (event) => {
  //   const email = event.target.value;
  //   console.log("email", email);
  //   this.setState({
  //     email: email,
  //   })
  // }
  // passwordHandler = (event) => {
  //   const password = event.target.value;
  //   console.log('password', password)
  //   this.setState({
  //     password: password
  //   })
  // }

  // submitHandler = (event) => {
  //   event.preventDefault();
  //   var data = {
  //     email: this.state.email,
  //     password: this.state.password
  //   }
  //   const response = loginEmployeeRequestHandler(data);
  //     response.then(res => {
  //       console.log(res);
  //       if (res.data === data.email) {
  //         this.setState({
  //           loginAuthentication: true
  //         })
  //       }
  //       this.props.history.push('/Dashboard');
  //     }).catch(()=>{
  //       //alert("email or password is incorrect");
  //       this.setState({
  //         showError:true
  //       })
  //     })
  // }
>>>>>>> 94232d33ace64fdab9adbcf9c6338da4cd36410a

  render() {
    
    return (
      <>
<<<<<<< HEAD
        <form className=" p-5 bg-light text-primary mx-auto" id='form' onSubmit={this.submitHandler}>
=======
        <form className=" p-5 bg-light text-primary mx-auto" id='form' >
>>>>>>> 94232d33ace64fdab9adbcf9c6338da4cd36410a
          <div className="form-group">
            <h1 className='display-3 text-dark'>Login</h1>
          </div>
          <div className="form-group">
            <label for="email">Email :</label>
<<<<<<< HEAD
            <input type="text" id="email" className="form-control " onChange={this.emailHandler} />
=======
            <input type="text" id="email" className="form-control "  />
>>>>>>> 94232d33ace64fdab9adbcf9c6338da4cd36410a

          </div>
          <div className="form-group">
            <label for="password">Password :</label>
<<<<<<< HEAD
            <input type="password" id="password" className="form-control " onChange={this.passwordHandler} />
          </div>
          {
            this.state.showError ? <div className="form-group text-danger" id="error">Email or Password is incorrect </div> : null
          }
=======
            <input type="password" id="password" className="form-control "  />
          </div>
          {/* {
            this.state.showError ? <div className="form-group text-danger" id="error">Email or Password is incorrect </div> : null
          } */}
>>>>>>> 94232d33ace64fdab9adbcf9c6338da4cd36410a
          
          <div className="form-group text-secondary">
            Don't have an account ? register
          </div>
          <button type="submit" className="btn btn-success" id="submitBtn">Login</button>
        </form>
      </>
    )
  }
}
export default Login  