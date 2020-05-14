import React, { Component } from 'react';
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

  render() {
    
    return (
      <>
        <form className=" p-5 bg-light text-primary mx-auto" id='form' >
          <div className="form-group">
            <h1 className='display-3 text-dark'>Login</h1>
          </div>
          <div className="form-group">
            <label for="email">Email :</label>
            <input type="text" id="email" className="form-control "  />

          </div>
          <div className="form-group">
            <label for="password">Password :</label>
            <input type="password" id="password" className="form-control "  />
          </div>
          {/* {
            this.state.showError ? <div className="form-group text-danger" id="error">Email or Password is incorrect </div> : null
          } */}
          
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