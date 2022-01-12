# MsLogManagement
Micro Services ExceptionLog Management Methods

<ul>
<li>  Every Micro Service logs contains in itself DB's </li>
<li>  Create Custom Log Micro Service </li>
<li>  Use RabbitMq and read with worker service </li>
</ul>

<p>As you know exception logs management is very important for developer.  And MicroService architecth  has a lot micro services. Developers has question "How can I do log management."   </p>
<p>This questions has many answers. These questions some answers are;
  
<ol>
  <li><strong>Every micro service logs create own db.</strong></li>
      <p></p>
    <li>Create custom exception log management micro service. Other services send logs this services and all logs write this service's db. </li>
    <li>Use RabbitMq and write db from RabbitMq queue.</li>
</ol>


