import { Button } from "primereact/button";
import { Card } from "primereact/card";
import { FloatLabel } from "primereact/floatlabel";
import { InputText } from "primereact/inputtext";
import { Password } from "primereact/password";
import React from "react";
import { Link } from "react-router-dom";
import { regexPatterns } from "../../common/constants";
import ErrorMessage from "../../components/common/field-error-message";
import { loginStyle } from "./style";

const Login = () => {
  const [formData, setFormData] = React.useState({} as any);
  const [fieldErrors, setFieldErrors] = React.useState({} as any);

  const handleChange = (e, isValidValue) => {
    const { name, value } = e.target;
    setFormData((prev) => ({ ...prev, [name]: value }));
    const errorMessage = !isValidValue
      ? `${name} is not valid`
      : !Boolean(value)
      ? `${name} is required`
      : "";
    setFieldErrors((prev) => ({ ...prev, [name]: errorMessage }));
  };

  const handleBlur = (e) => {
    const { name, value } = e?.target;
    if (!Boolean(value)) {
      setFieldErrors((prev) => ({
        ...prev,
        [name]: `${name} is required`,
      }));
    }
  };

  const getErrorNode = (field) => (
    <ErrorMessage message={fieldErrors?.[field]} />
  );

  const handleSubmit = (e: any) => {
    e?.preventDefault();
    console.log(formData);
  };

  console.log(fieldErrors);

  return (
    <div style={loginStyle.loginContainer}>
      <Card
        title="DealMate Login"
        className="shadow-5"
        style={{ width: "400px" }}
      >
        <form noValidate onSubmit={handleSubmit}>
          <div className="p-fluid">
            <div className="p-field" style={{ marginBottom: "25px" }}>
              <FloatLabel>
                <InputText
                  name="email"
                  id="email"
                  placeholder="Enter Email"
                  keyfilter={regexPatterns.email}
                  onInput={handleChange}
                  onBlur={handleBlur}
                  value={formData?.email}
                  invalid={Boolean(fieldErrors?.email)}
                  className="p-input"
                  validateOnly={true}
                  required
                />
                <label htmlFor="email">Email Id</label>
              </FloatLabel>
              {getErrorNode("email")}
            </div>
            <div className="p-field" style={{ marginBottom: "25px" }}>
              <FloatLabel>
                <Password
                  id="password"
                  name="password"
                  placeholder="Enter Password"
                  onChange={(e) => handleChange(e, true)}
                  onBlur={handleBlur}
                  value={formData?.password}
                  invalid={Boolean(fieldErrors?.password)}
                  feedback={false}
                  pt={{
                    input: { className: "p-input" },
                    showIcon: { style: { color: "green" } },
                  }}
                  toggleMask
                  required
                />
                <label htmlFor="password">Password</label>
              </FloatLabel>
              {getErrorNode("password")}
            </div>
            <div className="p-field mb-3 text-right">
              <div>
                <Link to="/forgot-password" style={{ textDecoration: "none" }}>
                  Forgot Password?
                </Link>
              </div>
            </div>
          </div>
          <div className="mb-3" style={loginStyle.button}>
            <Button label="Login" icon="pi pi-sign-in" />
          </div>
        </form>
        <div style={{ textAlign: "center" }}>
          Not a member?
          <Link to="/signup" style={{ textDecoration: "none" }}>
            &nbsp; Sign Up
          </Link>
        </div>
      </Card>
    </div>
  );
};

export default Login;
