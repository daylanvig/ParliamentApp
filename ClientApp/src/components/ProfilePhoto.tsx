import React from 'react';
import Politician from 'models/Politician';
import './ProfilePhoto.scss';

type ProfilePhotoProps = {
  politician?: Politician;
};

/**
 * Profile Photo Component
 * @returns 
 */
function ProfilePhoto({ politician }: ProfilePhotoProps) {

  // if politician has not been selected, we can render a placeholder here
  if (politician == null) {
    return (
      <div className='ProfilePhoto'>
        <figure className='image is-2by3'>
          <img src='https://via.placeholder.com/250x312?text=No+Selection' alt='Placeholder - No Politician Selected'></img>
        </figure>
      </div>
    );
  }

  let profilePhotoUrl = politician.getPhotoURL();
  let altLabel: string;
  if (profilePhotoUrl === undefined) {
    profilePhotoUrl = 'https://via.placeholder.com/250x312?text=No+Photo+Found';
    altLabel = `Placeholder for ${politician.getFullName()}`;
  } else {
    altLabel = `${politician.getFullName()}'s Profile`;
  }
  return (
    <a className='ProfilePhoto' href={politician.getLinkToProfile()} target="_blank" rel="noreferrer">
      <figure className='image is-2by3'>
        <img src={profilePhotoUrl} alt={altLabel}></img>
      </figure>
    </a>
  );
}
export default ProfilePhoto;