# MsLogManagement
Micro Services ExceptionLog Management Methods

<p>As you know exception logs management is very important for developers.  And MicroService architecth  has a lot micro services. Developers has question "How can I do log management."   </p>
<p>This questions has many answers. These questions some answers are;
  
<ol>
  <li>Every micro service logs create own's db.</li>
  <li>Create custom exception log management micro service. Other services send logs this services and all logs write this service's db. </li>
  <li>Use RabbitMq and write db from RabbitMq queue.</li>
</ol>


