import React, { Component } from 'react';
import FlexPicture from './flexPicture';

class Form extends Component {
  state = {
    data: {},
    errors: {},
    isLoading: true,
  };

  handleGoBack = () => {
    this.props.history.goBack();
  };

  handleRedirect = (url) => {
    this.props.history.push(url);
  };

  renderWithLoading(content) {
    let data = this.state.isLoading ? (
      <p>
        <em>Loading...</em>
      </p>
    ) : (
      content
    );

    return data;
  }

  renderButton(name, label, { ...rest }) {
    return (
      <a {...rest} name={name} className="btn btn-primary btn-block mb-3">
        {label}
      </a>
    );
  }

  renderOptionsFlex(name, { ...rest }) {
    const { data } = this.state;

    //console.log(data[name]);

    return (
      <div
        {...rest}
        name={name}
        className="d-flex flex-wrap justify-content-center mb-5"
      >
        {(data[name] || []).map((item) => (
          <FlexPicture
            key={item.id}
            id={item.id}
            filename={item.filename}
            label={item.label}
            onSelected={item.handleOptionSelected}
          />
        ))}
      </div>
    );
  }
}

export default Form;
